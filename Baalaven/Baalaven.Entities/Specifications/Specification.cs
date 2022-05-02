using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.Entities.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression { get; }
        public bool ISSatisfiedBy(T entity)
        {
            Func<T, bool> ExpressionDelegate = Expression.Compile();
            return ExpressionDelegate(entity);
        }
    }
}
