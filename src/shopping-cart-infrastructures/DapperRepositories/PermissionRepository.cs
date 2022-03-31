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
    public class PermissionRepository
    {
        private readonly IDapperBuilder _dapperBuilder;
        public PermissionRepository(IDapperBuilder dapperBuilder)
        {
            _dapperBuilder = dapperBuilder;
        }
        public async Task<IEnumerable<PermissionDto>> GetPermissionsByRoleId(Guid Id)
        {
            _dapperBuilder.Build<RolePermissionMapping>()
                .Join("Permissions t2")
                .Select("t2.Id")
                .Select("t2.Key")
                .Select("t2.Name")
                .Select("t2.Description")
                .Where("t1.RoleId = @roleId", new { roleId = Id });
            return await _dapperBuilder.GetEnumerable<PermissionDto>();
        }
    }
}
