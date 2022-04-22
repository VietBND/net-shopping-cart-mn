using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Entities;

namespace ShoppingCart.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
    }
}
