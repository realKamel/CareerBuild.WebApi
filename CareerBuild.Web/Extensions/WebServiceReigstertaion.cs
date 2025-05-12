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
	}
}
