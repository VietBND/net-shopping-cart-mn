using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Entities;

namespace shopping_cart.domain.Entities
{
    public class Role : AuditedEntity<Guid>
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Role()
        {
            UserRoleMappings = new HashSet<UserRoleMapping>();
            RolePermissionMappings = new HashSet<RolePermissionMapping>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<UserRoleMapping> UserRoleMappings { get; set; }
        public ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }
    }
}
