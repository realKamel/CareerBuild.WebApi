using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IUnitOfWork
	{
		//IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
		public IIdentityRepository<CompanyUserProfile> CompanyUserRepository { get; }
		public IIdentityRepository<RegularUserProfile> RegularUserRepository { get; }
		Task<int> SaveChangesAsync();
	}
}
