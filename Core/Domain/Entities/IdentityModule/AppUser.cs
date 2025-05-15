using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityModule
{
	public class AppUser : IdentityUser
	{
		#region Common Properties
		// Add common properties to Regular and Company users
		public Address Address { get; set; } = default!;
		public string? PictureUrl { get; set; } = default!;
		#endregion

		#region Extentions Profiles
		// one-to-one relationships
		[InverseProperty(nameof(RegularUserProfile.AppUser))]
		public RegularUserProfile RegularProfile { get; set; } = default!;

		[InverseProperty(nameof(CompanyUserProfile.AppUser))]
		public CompanyUserProfile CompanyProfile { get; set; } = default!;
		#endregion
	}
}
