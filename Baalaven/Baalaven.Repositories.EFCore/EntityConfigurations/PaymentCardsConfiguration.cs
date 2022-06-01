using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Baalaven.Entities.Enums;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class PaymentCardsConfiguration : IEntityTypeConfiguration<PaymentCards>
    {
        public void Configure(EntityTypeBuilder<PaymentCards> builder)
        {
            builder.Property(pc => pc.CardNumber)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(pc => pc.CardHolderName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(pc => pc.ExpireDate)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(pc => pc.CVVData)
                .IsRequired()
                .HasMaxLength(3);
            builder.HasData(
                new PaymentCards { Id = 1, CardType = CardType.Visa, CardNumber = "1234567893215765", CardHolderName = "OSCAR CAMA", ExpireDate = "042026", CVVData = 123},
                new PaymentCards { Id = 2, CardType = CardType.MasterCard, CardNumber = "7869372388034728", CardHolderName = "ABRAHAM HERNANDEZ", ExpireDate = "122027", CVVData = 456 },
                new PaymentCards { Id = 3, CardType = CardType.AmericanExpress, CardNumber = "8294782314653892", CardHolderName = "PIERO ALVARADO", ExpireDate = "072022", CVVData = 789 }
                );
        }
    }
}
