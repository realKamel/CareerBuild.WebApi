using Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbContexts
{
	public class IdentityContext(DbContextOptions<IdentityContext> options) :
		IdentityDbContext<AppUser>(options)
	{
		public DbSet<RegularUserProfile> RegularUserProfiles { get; set; }
		public DbSet<CompanyUserProfile> CompanyUserProfiles { get; set; }
		protected override void OnModelCreating(ModelBuilder b)
		{
			base.OnModelCreating(b);

			// Configure User table
			b.Entity<AppUser>().ToTable("Users");


			b.Entity<RegularUserProfile>()
			.HasOne(p => p.AppUser)
			.WithOne(p => p.RegularProfile) // Indicates a one-to-one relationship
			.HasForeignKey<RegularUserProfile>(p => p.AppUserId)
			.IsRequired();

			b.Entity<CompanyUserProfile>()
				.HasOne(p => p.AppUser)
				.WithOne(p => p.CompanyProfile)
				.HasForeignKey<CompanyUserProfile>(p => p.AppUserId)
				.IsRequired();

			b.Entity<IdentityRole>().ToTable("Roles");
			b.Entity<IdentityUserRole<string>>().ToTable("User_Roles");
			b.Entity<IdentityUserClaim<string>>().ToTable("User_Claims");
			b.Entity<IdentityRoleClaim<string>>().ToTable("Role_Claims");
			b.Entity<IdentityUserLogin<string>>().ToTable("User_Logins");

			b.Ignore<IdentityUserToken<string>>();

		}
	}
}
