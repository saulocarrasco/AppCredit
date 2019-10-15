using Data.TableConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class AppCreditDbContext : DbContext
    {
        public AppCreditDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressTableConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerTableConfiguration());
            modelBuilder.ApplyConfiguration(new FeeInformationTableConfiguration());
            modelBuilder.ApplyConfiguration(new IdentificationTableConfiguration());
            modelBuilder.ApplyConfiguration(new LoanTableConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserTableConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTableConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTableConfiguration());
        } 

    }
}
