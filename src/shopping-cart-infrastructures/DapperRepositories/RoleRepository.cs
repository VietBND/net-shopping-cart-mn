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
    public interface IRoleRepository
    {

    }
    public class RoleRepository : IRoleRepository
    {
        private readonly IDapperBuilder _dapperBuilder;
        public RoleRepository(IDapperBuilder dapperBuilder)
        {
            _dapperBuilder = dapperBuilder;
        }

        public async Task<RoleDto> GetByUserId(long userId)
        {
            _dapperBuilder.Build<UserRoleMapping>()
                .Join("Roles t2")
                .Select("t2.Id")
                .Select("t2.Name")
                .Select("t2.IsActive")
                .Select("t2.IsAdmin")
                .Where("t1.UserId = @userId",new { userId = userId });
            return await _dapperBuilder.SingleOrDefault<RoleDto>();
        }

        
    }
}
