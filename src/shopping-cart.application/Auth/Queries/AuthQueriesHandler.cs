using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shopping_cart.domain.Common;
using shopping_cart_infrastructures.DapperRepositories;
using shopping_cart_infrastructures.DapperRepositories.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VietBND.AspNetCore.Exceptions;
using VietBND.MediatR.Queries;

namespace shopping_cart.application.Auth.Queries
{
    public class AccountLoginQueries : IQuery<AccountLoginSuccessDto>
    {
        public string Username { get;set; }
        public string Password { get;set; }
        public bool RememberMe { get;set; }
    }
    public class AuthQueriesHandler : IQueryHandler<AccountLoginQueries, AccountLoginSuccessDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthQueriesHandler(IUserRepository userRepository, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public async Task<AccountLoginSuccessDto> Handle(AccountLoginQueries request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsername(request.Username);
            if (user == null)
                throw new BadRequestException("USERNAME_NOT_EXIST");
            if (!Encryption.Validate(user.Password, request.Password, user.Salt))
            {
                throw new BadRequestException("PASSWORD_IS_WRONG");
            }
            var token = generateJwtToken(user);
            var refreshToken = generateRefreshToken(ipAddress());
            setTokenCookie(refreshToken.Token);
            return new AccountLoginSuccessDto()
            {
                Toke
            };
        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            _contextAccessor.HttpContext.Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (_contextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                return _contextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
            else
                return _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private string generateJwtToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtBearer:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { 
                    new Claim("Username", $"{user.Username}"), 
                    new Claim("UserId", user.Id.ToString()) 
                }),
                Expires = DateTime.UtcNow.AddDays(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshTokenDto generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RSACryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.EncryptValue(randomBytes);
                return new RefreshTokenDto
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    CreatedAt = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }

    }
}
