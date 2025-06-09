using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CareerBuild.Web.Extensions
{
	public static class WebServiceRegistration
	{
		public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
		{
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			Services.AddEndpointsApiExplorer();
			Services.AddSwaggerGen();
			return Services;
		}
		public static IServiceCollection AddJWTService(this IServiceCollection Services, IConfiguration _configuration)
		{
			Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(config =>
			{
				config.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidIssuer = _configuration.GetSection("JWToptions")["issuer"],
					ValidateAudience = true,
					ValidAudience = _configuration.GetSection("JWToptions")["audience"],
					ValidateLifetime = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(_configuration.GetSection("JWToptions")["securityKey"]))
				};

			});

			return Services;
		}
		public static IServiceCollection AddAIWebHttpClient(this IServiceCollection Services, IConfiguration configuration)
		{
			// Register the AI service HTTP client
			// This assumes you have a section in your appsettings.json like:
			// "AIService": {
			//   "BaseUrl": "https://api.example.com",
			//   "ApiKey": "your-api-key"
			// }
			if (configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			if (!configuration.GetSection("AiHttpClient").Exists())
				throw new ArgumentException("AIService configuration section is missing.");

			var services = Services ?? throw new ArgumentNullException(nameof(Services));

			Services.AddHttpClient("AiHttpClient", client =>
			{
				client.BaseAddress = new Uri(configuration["AiHttpClient:BaseUrl"]);
				// client.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration["AIService:ApiKey"]}");
				client.DefaultRequestHeaders.Add("Accept", "application/json");
			});

			return services;
		}
	}
}
