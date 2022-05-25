using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using System.Collections.Generic;

namespace Baalaven.Entities.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByEspecification(Specification<Product> specification);
    }
}
