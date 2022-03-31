using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using shopping_cart_infrastructures.DapperRepositories;
using shopping_cart_infrastructures.RedisRepositories;
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
using VietBND.Redis;

namespace shopping_cart_infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>),typeof(EfRepository<,>));
            services.AddTransient<IDapperBuilder,DapperBuilder>();
            services.AddSingleton<IRedisStorage>(sp =>
            {
                return new RedisStorage();
            });
            services.AddSingleton<ISessionRedisRepository>(sp =>
            {
                var redisStorage = sp.GetRequiredService<IRedisStorage>();
                return new SessionRedisRepository(redisStorage);
            });
            services.AddSingleton<IDapperRepository>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var logger = sp.GetRequiredService<ILogger<DapperRepository>>();
                return new DapperRepository(DbType.SqlServer, configuration, logger);
            });
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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
