using Baalaven.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baalaven.Repositories.EFCore.EntityConfigurations
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.HasKey(pd => new { pd.IdPaymentDetails, pd.PaymentsId });
            builder.HasOne<PaymentCards>()
                .WithMany()
                .HasForeignKey(pd => pd.IdPaymentCard);
        }
    }
}
