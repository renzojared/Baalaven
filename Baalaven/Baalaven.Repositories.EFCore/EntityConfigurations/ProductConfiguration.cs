using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasData(
                    new Product { Id = 1, Name = "Chai" },
                    new Product { Id = 2, Name = "Chang" },
                    new Product { Id = 3, Name = "Aniseed Syrup" }
                );
        }
    }
}
