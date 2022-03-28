using shopping_cart.domain.Entities;
using shopping_cart_infrastructures.DapperRepositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Dapper;

namespace shopping_cart_infrastructures.DapperRepositories
{
    public interface IUserRepository
    {
        Task<UserDto> GetByUsername(string username);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDapperBuilder _dapperBuilder;
        public UserRepository(IDapperBuilder dapperBuilder)
        {
            _dapperBuilder = dapperBuilder;
        }
        public async Task<UserDto> GetByUsername(string username)
        {
            var builder = _dapperBuilder.Build<User>()
                .Where("t1.Username = @username", new { username = username })
                .Select("t1.Id")
                .Select("t1.Username")
                .Select("t1.Password")
                .Select("t1.Salt")
                .Select("t1.Name")
                .Select("t1.Email");
            return await _dapperBuilder.SingleOrDefault<UserDto>();
        }
    }
}
