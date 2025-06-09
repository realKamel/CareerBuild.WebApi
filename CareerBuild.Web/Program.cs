using CareerBuild.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
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


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddControllers();
			builder.Services.AddSwaggerServices();

			builder.Services.AddIdentityServices(builder.Configuration); //persistence layer

			builder.Services.AddAppCoreService(); //service layer

			builder.Services.AddJWTService(builder.Configuration);

			builder.Services.AddAIWebHttpClient(builder.Configuration); // AI service client

			builder.Services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = builder.Configuration.GetConnectionString("ValkeyConnection");
				options.InstanceName = "Valkey_"; // Optional: Set a prefix for cache keys
			});

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAngularApp",
					policy =>
					{
						policy.WithOrigins("http://localhost:4200")
							  .AllowAnyHeader()
							  .AllowAnyMethod();
					});
			});


			#endregion

			var app = builder.Build();

			try
			{
				await app.DataSeedingAsync();
			}
			catch (Exception e)
			{
				Log.Error(e, "An error occurred during data seeding.");
				throw;
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

			app.UseCors("AllowAngularApp"); // to enable request from Angular Project

			app.UseAuthorization(); // if we have role 

			app.MapControllers(); // maps api controllers

			#endregion
			app.Logger.LogInformation("Current Environment: {Env}", app.Environment.EnvironmentName);
			await app.RunAsync();
		}
	}
}