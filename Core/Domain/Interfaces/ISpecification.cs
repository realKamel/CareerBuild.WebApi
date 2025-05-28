using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
	public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public Expression<Func<TEntity, bool>>? Criteria { get; }
		public List<Expression<Func<TEntity, object>>> IncludeExp { get; }
		public Expression<Func<TEntity, object>> OrderBy { get; }
		public Expression<Func<TEntity, object>> OrderByDesc { get; }
	}
}
