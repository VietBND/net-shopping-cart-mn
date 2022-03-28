using Microsoft.EntityFrameworkCore;
using shopping_cart.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.EfCore;

namespace shopping_cart_infrastructures
{
    public class ShoppingCartDbContext : VBDbContext, IDbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
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
