using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public class PermissionTableConfiguration : TableConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            CommonColumnsConfiguration(builder);
        }
    }
}
