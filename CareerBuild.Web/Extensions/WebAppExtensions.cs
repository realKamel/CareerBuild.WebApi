using CareerBuild.Web.CustomMiddleWares;
using Domain.Interfaces;

namespace CareerBuild.Web.Extensions
{
	public static class WebAppExtensions
	{
		public static async Task DataSeedingAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var DataSeedingObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
			
			await DataSeedingObj.AppDataSeeding();// for app data
												 
			await DataSeedingObj.IdentityDataSeedingAsync(); // for identity data
		}

		public static IApplicationBuilder UseSwaggerMiddleware(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			return app;
		}

		public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
		{
			//to make request first go through this middleware
			app.UseMiddleware<CustomExceptionHandlerMiddleWare>();

			return app;
		}
	}

}
