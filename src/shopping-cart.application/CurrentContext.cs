using Microsoft.AspNetCore.Http;
using shopping_cart_infrastructures.RedisRepositories;
using shopping_cart_infrastructures.RedisRepositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application
{
    
    public interface ICurrentContext
    {
        Task<SessionCacheDto> GetCurrentAccount();
        Task SetLoginSuccess(string aid,Func<SessionCacheDto> func);
    }
    public class CurrentContext : ICurrentContext
    {
        private readonly ISessionRedisRepository _sessionRedisRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentContext(ISessionRedisRepository sessionRedisRepository, IHttpContextAccessor httpContextAccessor)
        {
            _sessionRedisRepository = sessionRedisRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<SessionCacheDto> GetCurrentAccount()
        {
            string aid = _httpContextAccessor.HttpContext.User.FindFirst("AID").Value;
            return await _sessionRedisRepository.GetCurrentAccount(aid);
        }

        public async Task SetLoginSuccess(string aid, Func<SessionCacheDto> sessionCacheDtoFunc)
        {
            var cacheDto = sessionCacheDtoFunc();
            await _sessionRedisRepository.SetCurrentAccount(aid,cacheDto);
        }
    }
}
