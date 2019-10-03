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
            modelBuilder.Entity<Address>().HasQueryFilter(i => i.IsDeleted == false);
            modelBuilder.Entity<Loan>().HasQueryFilter(i => i.IsDeleted == false);
            modelBuilder.Entity<Customer>().HasQueryFilter(i => i.IsDeleted == false);
            modelBuilder.Entity<FeeInformation>().HasQueryFilter(i => i.IsDeleted == false);
            modelBuilder.Entity<Identification>().HasQueryFilter(i => i.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FeeInformation> FeeInformation { get; set; }
        public DbSet<Identification> Identifications { get; set; }

    }
}
