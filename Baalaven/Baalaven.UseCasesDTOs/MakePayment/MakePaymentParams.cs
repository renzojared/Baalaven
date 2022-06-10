using System.Collections.Generic;

namespace Baalaven.UseCasesDTOs.MakePayment
{
    public class MakePaymentParams
    {
        public int OrderId { get; set; }
        public List<MakePaymentDetailsParams> PaymentDetails { get; set; }
    }
}
