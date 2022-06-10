using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using System.Collections.Generic;

namespace Baalaven.Entities.Interfaces
{
    public interface IPaymentDetailRepository
    {
        void Create(PaymentDetails paymentDetails);
        IEnumerable<PaymentDetails> GetPaymentDetailsByEspecification(Specification<PaymentDetails> specification);
    }
}
