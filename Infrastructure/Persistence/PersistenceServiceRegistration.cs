using Domain.Entities.IdentityModule;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;
using Persistence.Repositories;

namespace Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection Services,
			IConfiguration Configuration)
		{

			Services.AddDbContext<IdentityContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
			});

			Services.AddIdentityCore<AppUser>(options =>
			{
				options.User.RequireUniqueEmail = true;

			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<IdentityContext>();

			Services.AddScoped<IDataSeeding, DataSeeding>();

			Services.AddScoped<IUnitOfWork, UnitOfWork>();


			return Services;
		}
	}
}
