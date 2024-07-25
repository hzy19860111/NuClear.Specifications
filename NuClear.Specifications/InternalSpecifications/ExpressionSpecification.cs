using System;
using System.Linq.Expressions;

namespace NuClear.Specifications
{
    internal class ExpressionSpecification<TEntity> : Specification<TEntity> where TEntity : class
	{
		public ExpressionSpecification(Expression<Func<TEntity, bool>> expression)
		{
			this._expression = expression;
		}

		public override Expression<Func<TEntity, bool>> GetExpression()
		{
			return this._expression;
		}

		private Expression<Func<TEntity, bool>> _expression;
	}
}
