using System;
using System.Linq.Expressions;

namespace NuClear.Specifications
{
	internal class NotSpecification<TEntity> : Specification<TEntity> where TEntity : class
	{
		public NotSpecification(ISpecification<TEntity> specification)
		{
			this._specification = specification;
		}

		public override Expression<Func<TEntity, bool>> GetExpression()
		{
			UnaryExpression body = Expression.Not(this._specification.GetExpression().Body);
			return Expression.Lambda<Func<TEntity, bool>>(body, this._specification.GetExpression().Parameters);
		}

		private ISpecification<TEntity> _specification;
	}
}
