using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class FeeInformationTableConfiguration : TableConfiguration<FeeInformation>
    {
        public override void Configure(EntityTypeBuilder<FeeInformation> builder)
        {
            builder.ToTable("FeeInformations");
            CommonColumnsConfiguration(builder);
        }
    }
}
