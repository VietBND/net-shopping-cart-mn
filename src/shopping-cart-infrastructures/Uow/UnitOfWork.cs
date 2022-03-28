using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.Uow;

namespace shopping_cart_infrastructures.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _dbContext.Instance.Dispose();
        }

        public DatabaseFacade GetDatabase()
        {
            return _dbContext.Instance.Database;
        }

        public void SaveChange()
        {
            _dbContext.Instance.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
             await _dbContext.Instance.SaveChangesAsync();
        }
    }
}
