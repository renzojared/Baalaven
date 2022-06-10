using Baalaven.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Baalaven.UseCasesDTOs.MakePayment
{
    public class MakePaymentOutputPort
    {
        public List<MakePayments> Payments { get; set; } //Revisar si cambiar por GetPayments
    }

    public class MakePayments
    {
        public int OrderId { get; private set; }
        public decimal AmountPayable { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public List<MakePaymentDetails> PaymentDetails { get; set; }

        public MakePayments(int orderId, decimal amountPayable, PaymentStatus paymentStatus)
        {
            OrderId = orderId;
            AmountPayable = amountPayable;
            PaymentStatus = paymentStatus;
        }
        public void SetPaymentDetails(List<MakePaymentDetails> paymentDetails) => PaymentDetails = paymentDetails;
    }

    public class MakePaymentDetails
    {
        public int IdPaymentCard { get; private set; }
        public decimal PaidAmount { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public PaymentType PaymentType { get; private set; }

        public MakePaymentDetails(int idPaymentCard, decimal paidAmount, DateTime paymentDate, PaymentType paymentType)
        {
            IdPaymentCard = idPaymentCard;
            PaidAmount = paidAmount;
            PaymentDate = paymentDate;
            PaymentType = paymentType;
        }
    }
}
