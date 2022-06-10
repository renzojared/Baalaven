using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using System.Collections.Generic;

namespace Baalaven.Entities.Interfaces
{
    public interface IPaymentRepository
    {
        void Create(Payments payments);
        IEnumerable<Payments> GetPaymentsByEspecification(Specification<Payments> specification);
    }
}
