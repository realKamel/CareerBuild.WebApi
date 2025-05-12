using Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbContexts
{
	public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<AppUserBase>(options)
	{
		protected override void OnModelCreating(ModelBuilder b)
		{
			base.OnModelCreating(b);

			b.Entity<AppUserBase>().Property(x => x.UserType)
				.HasConversion<string>();

			b.Entity<AppUserBase>()
				.HasDiscriminator<UserType>(x => x.UserType)
				.HasValue<Company>(UserType.Company)
				.HasValue<AppUser>(UserType.User);

			b.Entity<AppUserBase>().ToTable("Users");
			b.Entity<IdentityRole>().ToTable("Roles");
			b.Entity<IdentityUserRole<string>>().ToTable("User_Roles");
			b.Ignore<IdentityUserToken<string>>();
		}
	}
}
