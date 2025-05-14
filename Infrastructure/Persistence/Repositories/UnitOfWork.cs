using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly IdentityContext _identityDb;
		private readonly Lazy<IIdentityRepository<CompanyUserProfile>> _companyUserRepository;
		private readonly Lazy<IIdentityRepository<RegularUserProfile>> _regularUserRepository;

		public UnitOfWork(IdentityContext identityDb)
		{
			this._identityDb = identityDb;
			_companyUserRepository = new Lazy<IIdentityRepository<CompanyUserProfile>>(() => new IdentityRepository<CompanyUserProfile>(_identityDb));
			_regularUserRepository = new Lazy<IIdentityRepository<RegularUserProfile>>(() => new IdentityRepository<RegularUserProfile>(_identityDb));
		}

		public IIdentityRepository<CompanyUserProfile>
			CompanyUserRepository => _companyUserRepository.Value;

		public IIdentityRepository<RegularUserProfile>
			RegularUserRepository => _regularUserRepository.Value;

		public async Task<int> SaveChangesAsync()
		{
			return await _identityDb.SaveChangesAsync();
		}
	}
}
