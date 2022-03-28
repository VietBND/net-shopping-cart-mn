using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Dapper;

namespace shopping_cart_infrastructures.Repositories
{
    public class DapperBuilder : BaseDapperBuilder<ShoppingCartDbContext>, IDapperBuilder
    {
        public DapperBuilder(IDapperRepository dapperRepository, ShoppingCartDbContext dbContext) : base(dapperRepository, dbContext)
        {
        }
    }
}
