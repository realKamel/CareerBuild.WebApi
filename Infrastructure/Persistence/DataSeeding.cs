using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class DataSeeding(IdentityContext _identityDb,
		UserManager<AppUser> _userManager,
		RoleManager<IdentityRole> _roleManager, AppDbContext _appDb) : IDataSeeding
	{
		public async Task AppDataSeeding()
		{
			try
			{
				var pendingMigration = await _identityDb.Database.GetPendingMigrationsAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task IdentityDataSeedingAsync()
		{
			try
			{
				var pendingMigration = await _identityDb.Database.GetPendingMigrationsAsync();

				if (pendingMigration.Any())
				{
					await _identityDb.Database.MigrateAsync();
				}
				if (!_roleManager.Roles.Any())
				{
					await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
				}
				if (!_userManager.Users.Any())
				{
					var user = new AppUser()
					{
						Email = "Abdelrahman@gmail.com",
						PhoneNumber = "01014202765",
						Address = new Address() { Street = "123", City = "Giza", Country = "Egypt" },
						UserName = "abdelrahman"
					};

					await _userManager.CreateAsync(user, "P@assw0rd");

					await _userManager.AddToRoleAsync(user, "SuperAdmin");
				}
				await _identityDb.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
