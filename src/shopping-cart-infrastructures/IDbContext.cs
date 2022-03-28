using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart_infrastructures
{
    public interface IDbContext
    {
        ShoppingCartDbContext Instance { get; }
    }
}
