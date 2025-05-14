using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IIdentityRepository<TEntity> where TEntity : class
	{
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
		Task<TEntity?> GetByIdAsync(string id);
		Task<IEnumerable<TEntity>> GetAllAsync();

		// to apply Specifications Design pattern
		//Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications);
		//Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications);

		//Task<int> CountAsync(ISpecifications<TEntity, TKey> specifications);
	}
}
