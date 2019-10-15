using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
{
    public class PaymentTableConfiguration : TableConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            CommonColumnsConfiguration(builder);
        }
    }
}
