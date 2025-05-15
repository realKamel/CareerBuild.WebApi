
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	internal class IdentityRepository<TEntity>(IdentityDbContext<AppUser> _dbContext) : IIdentityRepository<TEntity> where TEntity : class
	{
		public async Task AddAsync(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbContext.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity?> GetByIdAsync(string id)
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
	}
}
