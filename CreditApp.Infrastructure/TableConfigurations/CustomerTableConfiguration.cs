using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class CustomerTableConfiguration : TableConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            CommonColumnsConfiguration(builder);
        }
    }
}
