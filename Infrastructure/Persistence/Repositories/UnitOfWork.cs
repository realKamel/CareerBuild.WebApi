using Domain.Entities;
using Domain.Interfaces;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UnitOfWork(AppDbContext _dbContext) : IUnitOfWork
	{
		//Dictionary for the created Repos
		private Dictionary<string, object> _repositories = [];

		public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
		{
			//get type name 
			var typeName = typeof(TEntity).Name;
			if (_repositories.TryGetValue(typeName, out object? value))
			{
				return value as IGenericRepository<TEntity, TKey>;
			}
			else
			{
				//1. Create object 
				var newTypeObject = new GenericRepository<TEntity, TKey>(_dbContext);
				//2. Store in Dictionary
				_repositories[typeof(TEntity).Name] = newTypeObject;
				//3. return the new object
				return newTypeObject;
			}
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}