using System;
using System.Linq.Expressions;

namespace Baalaven.Entities.Specifications
{
    public class Specification<T>
    {
        public Expression<Func<T, bool>> Expression { get; private set; }

        public Specification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool ISSatisfiedBy(T entity)
        {
            Func<T, bool> ExpressionDelegate = Expression.Compile();
            return ExpressionDelegate(entity);
        }
    }
}
