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
    internal class RolePermissionMappingEntityConfiguration : BaseEntityConfiguration<RolePermissionMapping, Guid>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionMapping> builder)
        {
            builder.HasKey("RoleId", "PermissionId");
            builder.HasOne(s => s.Role).WithMany(s => s.RolePermissionMappings).HasForeignKey(s => s.RoleId);
            builder.HasOne(s => s.Permission).WithMany(s => s.RolePermissionMappings).HasForeignKey(s => new { s.PermissionId });
            builder.Ignore(s => s.Id);
        }
    }
}
