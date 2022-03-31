using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopping_cart.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Domain.EntityConfigurations;

namespace shopping_cart_infrastructures.EntityConfigurations
{
    internal class UserRoleMappingEntityConfiguration : BaseEntityConfiguration<UserRoleMapping, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
            builder.HasKey(s => new { s.RoleId, s.UserId });
            builder.HasOne(s => s.Role).WithMany(s => s.UserRoleMappings).HasForeignKey(s => s.RoleId);
            builder.HasOne(s => s.User).WithMany(s => s.UserRoleMappings).HasForeignKey(s => s.UserId);
            builder.Ignore(s => s.Id);
        }
    }
}
