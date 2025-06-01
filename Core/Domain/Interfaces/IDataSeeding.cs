
namespace Domain.Interfaces
{
	public interface IDataSeeding
	{
		Task AppDataSeeding();
		Task IdentityDataSeedingAsync();
	}
}
