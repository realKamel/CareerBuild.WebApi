using CareerBuild.Web.Extensions;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.DbContexts;
using Serilog;
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
			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration)
				.Enrich.FromLogContext()
				.CreateLogger();

			builder.Host.UseSerilog(); // Use Serilog for logging
			builder.Logging.ClearProviders();
			builder.Logging.AddSerilog();


			builder.Services
				.AddControllers(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

			builder.Services.AddSwaggerServices(); // web

			builder.Services.AddIdentityServices(builder.Configuration); //persistence layer

			builder.Services.AddAppCoreService(); //service layer

			builder.Services.AddJWTService(builder.Configuration);

			#endregion

			var app = builder.Build();

			try
			{
				await app.DataSeedingAsync();
			}
			catch (Exception e)
			{
				Log.Error(e, "An error occurred during data seeding.");
			}

			#region Middlewares

			// Configure the HTTP request pipeline.
			app.UseSerilogRequestLogging();

			app.UseCustomExceptionMiddleware(); // to enable exceptions

			app.UseSwaggerMiddleware(); //to enable swagger in development

			app.UseHttpsRedirection(); // to enable https

			app.UseStaticFiles(); //if we static file we can now use it

			app.UseRouting(); // enabled explicitly

			app.UseAuthentication(); // if we have login

			app.UseCors("AllowAngularDevClient"); // to enable request from Angular Project

			app.UseAuthorization(); // if we have role 

			app.MapControllers(); // maps api controllers

			#endregion

			await app.RunAsync();
		}
	}
}