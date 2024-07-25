﻿namespace NuClear.Specifications
{
    internal abstract class CompositeSpecification<TEntity> : Specification<TEntity>, ICompositeSpecification<TEntity>, ISpecification<TEntity> where TEntity : class
	{
		public CompositeSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
		{
			this.Left = left;
			this.Right = right;
		}

		public ISpecification<TEntity> Left { get; private set; }

		public ISpecification<TEntity> Right { get; private set; }
	}
}
