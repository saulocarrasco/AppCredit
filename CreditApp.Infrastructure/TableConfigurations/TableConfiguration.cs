using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditApp.Infrastructure.TableConfigurations
{
    public abstract class TableConfiguration<T> : IEntityTypeConfiguration<T> where T : TransactionEntity
    {
        protected void CommonColumnsConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.HasQueryFilter(p => p.IsDeleted == false);
        }
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
