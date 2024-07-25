using System;
using System.Linq.Expressions;

namespace NuClear.Specifications
{
	public abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
	{
		public static ISpecification<TEntity> Create(Expression<Func<TEntity, bool>> expression)
		{
			return new ExpressionSpecification<TEntity>(expression);
		}

		public virtual bool IsSatisfiedBy(TEntity entity)
		{
			return this.GetExpression().Compile()(entity);
		}

		public virtual ISpecification<TEntity> And(ISpecification<TEntity> other)
		{
			if (other == null)
			{
				return this;
			}
			return new AndSpecification<TEntity>(this, other);
		}

		public virtual ISpecification<TEntity> Or(ISpecification<TEntity> other)
		{
			if (other == null)
			{
				return this;
			}
			return new OrSpecification<TEntity>(this, other);
		}

		public virtual ISpecification<TEntity> AndNot(ISpecification<TEntity> other)
		{
			if (other == null)
			{
				return this;
			}
			return new AndNotSpecification<TEntity>(this, other);
		}

		public virtual ISpecification<TEntity> Not()
		{
			return new NotSpecification<TEntity>(this);
		}

		public abstract Expression<Func<TEntity, bool>> GetExpression();
	}
}
