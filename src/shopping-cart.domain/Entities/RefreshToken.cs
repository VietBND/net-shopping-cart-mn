using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Entities;

namespace shopping_cart.domain.Entities
{
    public class RefreshToken : AuditedEntity<Guid>
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByIp;
    }
}
