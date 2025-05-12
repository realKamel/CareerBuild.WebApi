using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityModule
{
	public abstract class AppUserBase : IdentityUser
	{
		public Address Address { get; set; } = default!;
		public string? PictureUrl { get; set; } = default!;
		public UserType UserType { get; set; }
	}
}
