using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class IdentificationTableConfiguration : TableConfiguration<Identification>
    {
        public override void Configure(EntityTypeBuilder<Identification> builder)
        {
            builder.ToTable("Identifications");
            CommonColumnsConfiguration(builder);
        }
    }
}
