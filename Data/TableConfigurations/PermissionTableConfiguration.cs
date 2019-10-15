using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
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
