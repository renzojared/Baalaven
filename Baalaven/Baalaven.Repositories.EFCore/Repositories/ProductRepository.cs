using Baalaven.Entities.Interfaces;
using Baalaven.Entities.POCOEntities;
using Baalaven.Entities.Specifications;
using Baalaven.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.Repositories.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly BaalavenContext context;

        public ProductRepository(BaalavenContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductsByEspecification(Specification<Product> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return context.Products.Where(expressionDelegate);
        }
    }
}
