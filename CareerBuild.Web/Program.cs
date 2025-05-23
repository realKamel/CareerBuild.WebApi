using CareerBuild.Web.Extensions;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.DbContexts;
//using Persistence.Repositories;
using Services;

namespace CareerBuild.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			#region DI Services Container

			// Add services to the container.

			builder.Services
				.AddControllers(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			builder.Services.AddSwaggerServices(); // web

			builder.Services.AddIdentityServices(builder.Configuration); //persistence layer

			builder.Services.AddAppCoreService(); //service layer

			#endregion

			var app = builder.Build();

			try
			{
				await app.DataSeedingAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			#region Middlewares

			// Configure the HTTP request pipeline.

			app.UseCustomExceptionMiddleware(); // to enable exceptions

			app.UseSwaggerMiddleware(); //to enable swagger in development

			app.UseHttpsRedirection(); // to enable https

			app.UseStaticFiles(); //if we static file we can now use it

			app.UseRouting(); // enabled explicitly

			app.UseAuthentication(); // if we have login

			app.UseAuthorization(); // if we have role 

			app.MapControllers(); // maps api controllers

			#endregion

			app.Run();
		}
	}
}