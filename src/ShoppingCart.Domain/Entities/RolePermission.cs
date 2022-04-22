using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Entities;

namespace ShoppingCart.Domain.Entities
{
    public class RolePermission : AuditedEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}
