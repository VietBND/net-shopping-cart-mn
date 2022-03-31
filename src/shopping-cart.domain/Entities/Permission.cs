using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain;

namespace shopping_cart.domain.Entities
{
    public class Permission : Entity<Guid>
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Permission()
        {
            RolePermissionMappings = new HashSet<RolePermissionMapping>();
        }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }
    }
}
