using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shopping_cart.domain.Entities;
using shopping_cart_infrastructures.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VietBND.EfCore;

namespace shopping_cart_infrastructures
{
    public class ShoppingCartDbContext : VBDbContext, IDbContext
    {
        private readonly IConfiguration _configuration;
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                .Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            Seeds.SeedHelper.GenerateDataWithCsvFile(_configuration.GetConnectionString("Default")).Wait();
        }
        public ShoppingCartDbContext Instance => this;
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<RolePermissionMapping> RolePermissionMappings { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
