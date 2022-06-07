using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Baalaven.Repositories.EFCore.Repositories
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        readonly BaalavenContext Context;

        public PaymentDetailRepository(BaalavenContext context) => Context = context;

        public void Create(PaymentDetails paymentDetails)
        {
            Context.Add(paymentDetails);
        }

        public IEnumerable<PaymentDetails> GetPaymentDetailsByEspecification(Specification<PaymentDetails> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return Context.PaymentDetails.Where(expressionDelegate);
        }
    }
}
