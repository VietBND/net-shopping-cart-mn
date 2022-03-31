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
    public class UserEntityConfiguration : BaseEntityConfiguration<User,long>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
        }
    }
}
