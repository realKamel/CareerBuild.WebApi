﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class GenericRepository<TEntity, TKey>(AppDbContext _dbContext)
		: IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		public async Task AddAsync(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbContext.Set<TEntity>().ToListAsync();
		}



		public async Task<TEntity?> GetByIdAsync(TKey id)
		{
			return await _dbContext.Set<TEntity>().FindAsync(id);
		}


		public void Remove(TEntity entity)
		{
			_dbContext.Set<TEntity>().Remove(entity);
		}

		public void Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
		}

		#region Specification
		public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specification)
		{
			return await QueryCreate.CreateQuery(_dbContext.Set<TEntity>(), specification).ToListAsync();
		}
		public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specification)
		{
			return await QueryCreate.CreateQuery(_dbContext.Set<TEntity>(), specification).FirstOrDefaultAsync();
		}
		#endregion
	}
}
