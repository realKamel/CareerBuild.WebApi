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
					ValidIssuer = _configuration.GetSection("JWToptions") [ "issuer" ],
					ValidateAudience = true,
					ValidAudience = _configuration.GetSection("JWToptions") [ "audience" ],
					ValidateLifetime = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(_configuration.GetSection("JWToptions") [ "securityKey" ]))
				};

			});

			return Services;
		}
	}
}
