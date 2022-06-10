using Baalaven.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Baalaven.Presenters.MakePaymentsDTO
{
    public class MakePaymentsOutput
    {
        public List<Payment> Payments { get; set; }
    }

    public class Payment
    {
        public int OrderId { get; set; }
        public decimal AmountPayable { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
    }

    public class PaymentDetail
    {
        public int IdPaymentCard { get;  set; }
        public decimal PaidAmount { get;  set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
