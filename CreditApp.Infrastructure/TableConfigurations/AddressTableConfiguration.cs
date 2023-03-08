using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class AddressTableConfiguration : TableConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            CommonColumnsConfiguration(builder);
        }
    }
}
