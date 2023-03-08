using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
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
