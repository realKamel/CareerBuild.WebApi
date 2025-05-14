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
	public class UnitOfWork(IdentityContext _identityDb) : IUnitOfWork
	{
		public IIdentityRepository<CompanyUserProfile> CompanyUserRepository
		{ get; set; }
		public IIdentityRepository<RegularUserProfile> RegularUserRepository
		{ get; set; }

		public async Task<int> SaveChangesAsync()
		{
			return await _identityDb.SaveChangesAsync();
		}
	}
}
