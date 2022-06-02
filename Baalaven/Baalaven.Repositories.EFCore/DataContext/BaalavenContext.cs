using Baalaven.Entities.POCOEntities;
using Baalaven.Repositories.EFCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Baalaven.Repositories.EFCore.DataContext
{
    public class BaalavenContext : DbContext
    {
        public BaalavenContext(DbContextOptions<BaalavenContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<PaymentCards> PaymentCards { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentCardsConfiguration());            
        }

    }
}
