using System;
using System.Linq.Expressions;

namespace NuClear.Specifications
{
    internal class AndNotSpecification<TEntity> : CompositeSpecification<TEntity> where TEntity : class
	{
		public AndNotSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right) : base(left, right)
		{
		}

		public override Expression<Func<TEntity, bool>> GetExpression()
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
			ParameterReplacer parameterReplacer = new ParameterReplacer(parameterExpression);
			Expression left = parameterReplacer.Replace(base.Left.GetExpression().Body);
			Expression right = parameterReplacer.Replace(Expression.Not(base.Right.GetExpression().Body));
			BinaryExpression body = Expression.And(left, right);
			return Expression.Lambda<Func<TEntity, bool>>(body, new ParameterExpression[]
			{
				parameterExpression
			});
		}
	}
}
