﻿// <auto-generated />
using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppCredit.Api.Migrations
{
    [DbContext(typeof(AppCreditDbContext))]
    partial class AppCreditDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .IsRequired();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Region");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("BirthDate");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Data.Entities.FeeInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CapitalPayment");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .IsRequired();

                    b.Property<decimal>("CurrentAmount");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("LoanId");

                    b.Property<int>("Number");

                    b.Property<decimal>("RateAmount");

                    b.Property<decimal>("TotalFee");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("FeeInformation");
                });

            modelBuilder.Entity("Data.Entities.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("CreationDate")
                        .IsRequired();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<int>("Doctype");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Identification");
                });

            modelBuilder.Entity("Data.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Begining");

                    b.Property<DateTimeOffset?>("CreationDate")
                        .IsRequired();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<DateTimeOffset>("End");

                    b.Property<int>("FeesNumber");

                    b.Property<double>("GrossProfit");

                    b.Property<bool>("IsDeleted");

                    b.Property<double>("LoanAmount");

                    b.Property<int>("PaymentMethod");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("Data.Entities.Address", b =>
                {
                    b.HasOne("Data.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Data.Entities.FeeInformation", b =>
                {
                    b.HasOne("Data.Entities.Loan", "Loan")
                        .WithMany("FeeInformations")
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("Data.Entities.Identification", b =>
                {
                    b.HasOne("Data.Entities.Customer", "Customer")
                        .WithMany("Identifications")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Data.Entities.Loan", b =>
                {
                    b.HasOne("Data.Entities.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
