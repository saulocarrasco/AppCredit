using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
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
