using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.HasData(
                new Customer { Id = "ALFKI", Name = "Alfreds F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );
        }
    }
}
