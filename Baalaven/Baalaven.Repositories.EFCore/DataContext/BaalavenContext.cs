using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.Repositories.EFCore.DataContext
{
    public class BaalavenContext : DbContext
    {
        public BaalavenContext(DbContextOptions<BaalavenContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddres)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)                
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode)
                .HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProducId });

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProducId);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Name = "Chai" },
                    new Product { Id = 2, Name = "Chang" },
                    new Product { Id = 3, Name = "Aniseed Syrup" }
                );

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = "ALFKI", Name = "Alfreds F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );

        }

    }
}
