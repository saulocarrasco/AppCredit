using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.TableConfigurations
{
    public class UserTableConfiguration : TableConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            CommonColumnsConfiguration(builder);
        }
    }
}
