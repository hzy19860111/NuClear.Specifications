using System;
using System.Linq.Expressions;

namespace NuClear.Specifications
{
    public interface ISpecification<TEntity> where TEntity : class
	{
		bool IsSatisfiedBy(TEntity entity);

		ISpecification<TEntity> And(ISpecification<TEntity> other);

		ISpecification<TEntity> Or(ISpecification<TEntity> other);

		ISpecification<TEntity> AndNot(ISpecification<TEntity> other);

		ISpecification<TEntity> Not();

		Expression<Func<TEntity, bool>> GetExpression();
	}
}
