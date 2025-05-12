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

namespace Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services,
			IConfiguration _config)
		{

			services.AddDbContext<IdentityContext>(options =>
			{
				options.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
			});

			services.AddIdentityCore<AppUserBase>(options =>
			{
				options.User.RequireUniqueEmail = true;

			}).AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

			services.AddScoped<IDataSeeding, DataSeeding>();

			return services;
		}
	}
}
