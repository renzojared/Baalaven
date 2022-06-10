using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.Repositories.EFCore.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace Baalaven.Repositories.EFCore.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        readonly BaalavenContext Context;
        public PaymentRepository(BaalavenContext context) => Context = context;

        public void Create(Payments payment)
        {
            Context.Add(payment);
        }
        public IEnumerable<Payments> GetPaymentsByEspecification(Specification<Payments> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Payments.Where(ExpressionDelegate);
        }
    }
}
