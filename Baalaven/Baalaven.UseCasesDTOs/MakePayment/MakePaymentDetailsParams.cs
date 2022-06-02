using Baalaven.Entities.Enums;

namespace Baalaven.UseCasesDTOs.MakePayment
{
    public class MakePaymentDetailsParams
    {
        public decimal PaidAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int IdPaymentCard { get; set; }
    }
}
