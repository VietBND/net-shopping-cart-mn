using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application.Auth.Queries
{
    public class AccountLoginSuccessDto
    {
        public string AccessToken { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
