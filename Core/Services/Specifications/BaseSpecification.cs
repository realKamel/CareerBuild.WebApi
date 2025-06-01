using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace Services.Specifications
{
	abstract public class BaseSpecification<TEntity, TKey>
		: ISpecification<TEntity, TKey> where TEntity
		: BaseEntity<TKey>
	{
		#region Where

		protected BaseSpecification(Expression<Func<TEntity, bool>>? CriteriaExp)
		{
			Criteria = CriteriaExp;
		}

		public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

		#endregion

		#region Include

		public List<Expression<Func<TEntity, object>>> IncludeExp { get; } = [];
		public List<string> IncludeStrings { get; } = [];
		public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ThenIncludeExp { get; } = [];


		protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
			=> IncludeExp.Add(includeExp);

		protected void AddInclude(string includeString) // For ThenInclude using string paths
		{
			IncludeStrings.Add(includeString);
		}

		#endregion

		#region OrderBy

		public Expression<Func<TEntity, object>> OrderBy { get; private set; }

		public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

		protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression) =>
			OrderBy = OrderByExpression;

		protected void AddOrderByDecs(Expression<Func<TEntity, object>> OrderByDescExpression) =>
			OrderByDesc = OrderByDescExpression;

		#endregion
	}
}