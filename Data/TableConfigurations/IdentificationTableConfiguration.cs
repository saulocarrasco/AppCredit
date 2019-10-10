using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
{
    public class IdentificationTableConfiguration : TableConfiguration<Identification>
    {
        public override void Configure(EntityTypeBuilder<Identification> builder)
        {
            CommonColumnsConfiguration(builder);
        }
    }
}
