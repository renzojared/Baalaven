using Baalaven.Entities.Enums;
using System;

namespace Baalaven.Entities.POCOEntities
{
    public class PaymentDetails
    {
        public int IdPaymentDetails { get; set; }
        public int IdPayment { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public int IdPaymentCard { get; set; }
        public Payments Payments { get; set; }
    }
}
