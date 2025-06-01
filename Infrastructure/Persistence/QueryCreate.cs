using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence
{
	static class QueryCreate
	{
		public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery,
			ISpecification<TEntity, TKey> specification) where TEntity : BaseEntity<TKey>
		{
			var Query = InputQuery;

			if (specification.Criteria is not null)
			{
				Query = Query.Where(specification.Criteria);
			}

			if (specification.OrderBy is not null)
			{
				Query = Query.OrderBy(specification.OrderBy);
			}

			if (specification.OrderByDesc is not null)
			{
				Query = Query.OrderByDescending(specification.OrderByDesc);
			}

			if (specification.IncludeExp is not null && specification.IncludeExp.Count > 0)
			{
				Query = specification.IncludeExp.Aggregate(Query,
					(Current, IncludeExp) =>
						Current.Include(IncludeExp));
			}

			if (specification.IncludeStrings is not null && specification.IncludeStrings.Count > 0)
			{
				Query = specification.IncludeStrings.Aggregate(
					Query, (curr, IncludeStringItems) =>
						curr.Include(IncludeStringItems));
			}

			return Query;
		}
	}
}