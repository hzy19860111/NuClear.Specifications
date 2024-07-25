namespace NuClear.Specifications
{
    internal interface ICompositeSpecification<TEntity> : ISpecification<TEntity> where TEntity : class
	{
		ISpecification<TEntity> Left { get; }

		ISpecification<TEntity> Right { get; }
	}
}
