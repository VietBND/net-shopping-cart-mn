using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shopping_cart_infrastructures.DapperRepositories;
using shopping_cart_infrastructures.Repositories;
using shopping_cart_infrastructures.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Dapper;
using VietBND.Domain.Repositories;
using VietBND.Domain.Uow;

namespace shopping_cart_infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>),typeof(EfRepository<,>));
            services.AddScoped(typeof(IDapperBuilder),typeof(DapperBuilder));
            services.AddSingleton<IDbContext>(sp =>
            {
                var options = sp.GetRequiredService<DbContextOptions<ShoppingCartDbContext>>();
                return new ShoppingCartDbContext(options);
            });
            services.AddSingleton<IUnitOfWork>(sp =>
            {
                var dbContext = sp.GetRequiredService<IDbContext>();
                return new UnitOfWork(dbContext.Instance);
            });
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            return services;
        }
    }
}
