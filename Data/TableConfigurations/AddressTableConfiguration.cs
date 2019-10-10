using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
{
    public class AddressTableConfiguration : TableConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasQueryFilter(i => i.IsDeleted == false);

            CommonColumnsConfiguration(builder);
        }
    }
}
