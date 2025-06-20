﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.Interfaces
{
	public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public Expression<Func<TEntity, bool>>? Criteria { get; }
		public List<Expression<Func<TEntity, object>>> IncludeExp { get; }
		public List<string> IncludeStrings { get; }

		public Expression<Func<TEntity, object>>? OrderBy { get; }
		public Expression<Func<TEntity, object>>? OrderByDesc { get; }
		public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>> ThenIncludeExp { get; }
	}
}