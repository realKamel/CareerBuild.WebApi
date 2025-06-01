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
		protected override void OnModelCreating(ModelBuilder b)
		{
			base.OnModelCreating(b);

			// Configure User table
			b.Entity<AppUser>().ToTable("Users");

			b.Entity<AppUser>()
			// Add a discriminator column named "UserType" oftype string
			.HasDiscriminator<string>("UserType")
			.HasValue<RegularUser>("Regular")// Store "Regular" if the row is a  RegularUser
			.HasValue<CompanyUser>("Company");// Store "Company" if the row is a CompanyUser

			// Note: we need a HasValue for the base AppUser if it's not abstract

			b.Entity<IdentityRole>().ToTable("Roles");
			b.Entity<IdentityUserRole<string>>().ToTable("User_Roles");
			b.Entity<IdentityUserClaim<string>>().ToTable("User_Claims");
			b.Entity<IdentityRoleClaim<string>>().ToTable("Role_Claims");
			b.Entity<IdentityUserLogin<string>>().ToTable("User_Logins");

			b.Ignore<IdentityUserToken<string>>();

		}
	}
}
