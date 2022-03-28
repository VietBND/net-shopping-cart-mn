using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Entities;

namespace shopping_cart.domain.Entities
{
    public class UserRoleMapping : AuditedEntity<Guid>
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserRoleMapping()
        {
        }
        public long UserId { get; set; }
        public virtual User User { get; set; } 
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
