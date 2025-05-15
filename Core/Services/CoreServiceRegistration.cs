using AbstractServices;
using Microsoft.Extensions.DependencyInjection;
using Services.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public static class CoreServiceRegistration
	{
		public static IServiceCollection AddAppCoreService(this IServiceCollection Services)
		{
			// to make this add profile automatically
			Services.AddAutoMapper(typeof(IdentityMappingProfile).Assembly);

			//for Services Manger
			Services.AddScoped<IServiceManager, ServiceManager>();
			return Services;
		}
	}
}
