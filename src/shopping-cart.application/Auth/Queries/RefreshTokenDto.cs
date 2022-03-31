using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application.Auth.Queries
{
    public class RefreshTokenDto
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime Expires { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByIp;
    }
}
