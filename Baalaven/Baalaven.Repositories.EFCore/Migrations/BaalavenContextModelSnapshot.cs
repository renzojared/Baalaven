﻿// <auto-generated />
using System;
using Baalaven.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Baalaven.Repositories.EFCore.Migrations
{
    [DbContext(typeof(BaalavenContext))]
    partial class BaalavenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = "ALFKI",
                            Name = "Alfreds F."
                        },
                        new
                        {
                            Id = "ANATR",
                            Name = "Ana Trujillo"
                        },
                        new
                        {
                            Id = "ANTON",
                            Name = "Antonio Moreno"
                        });
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ShipCity")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipCountry")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipPostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ShippingType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.PaymentCards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVVData")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("CardType")
                        .HasColumnType("int");

                    b.Property<string>("ExpireDate")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("PaymentCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CVVData = 123,
                            CardHolderName = "OSCAR CAMA",
                            CardNumber = "1234567893215765",
                            CardType = 1,
                            ExpireDate = "042026"
                        },
                        new
                        {
                            Id = 2,
                            CVVData = 456,
                            CardHolderName = "ABRAHAM HERNANDEZ",
                            CardNumber = "7869372388034728",
                            CardType = 0,
                            ExpireDate = "122027"
                        },
                        new
                        {
                            Id = 3,
                            CVVData = 789,
                            CardHolderName = "PIERO ALVARADO",
                            CardNumber = "8294782314653892",
                            CardType = 2,
                            ExpireDate = "072022"
                        });
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.PaymentDetails", b =>
                {
                    b.Property<int>("IdPaymentDetails")
                        .HasColumnType("int");

                    b.Property<int>("PaymentsId")
                        .HasColumnType("int");

                    b.Property<int>("IdPaymentCard")
                        .HasColumnType("int");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("IdPaymentDetails", "PaymentsId");

                    b.HasIndex("IdPaymentCard");

                    b.HasIndex("PaymentsId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Payments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPayable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .IsFixedLength(true);

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chai"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chang"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aniseed Syrup"
                        });
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Order", b =>
                {
                    b.HasOne("Baalaven.Entities.POCOEntities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.OrderDetail", b =>
                {
                    b.HasOne("Baalaven.Entities.POCOEntities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Baalaven.Entities.POCOEntities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.PaymentDetails", b =>
                {
                    b.HasOne("Baalaven.Entities.POCOEntities.PaymentCards", null)
                        .WithMany()
                        .HasForeignKey("IdPaymentCard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Baalaven.Entities.POCOEntities.Payments", "Payments")
                        .WithMany()
                        .HasForeignKey("PaymentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Baalaven.Entities.POCOEntities.Payments", b =>
                {
                    b.HasOne("Baalaven.Entities.POCOEntities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
