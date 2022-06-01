using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.HasKey(pd => new { pd.IdPaymentDetails, pd.IdPayment });
            builder.HasOne<Payments>()
                .WithMany()
                .HasForeignKey(pd => pd.IdPayment);
            builder.HasOne<PaymentCards>()
                .WithMany()
                .HasForeignKey(pd => pd.IdPaymentCard);
        }
    }
}
