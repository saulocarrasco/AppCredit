using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class LoanTableConfiguration : TableConfiguration<Loan>
    {
        public override void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");
            CommonColumnsConfiguration(builder);
        }
    }
}
