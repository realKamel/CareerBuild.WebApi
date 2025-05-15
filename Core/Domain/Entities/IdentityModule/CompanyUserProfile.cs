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
	public class CompanyUserProfile
	{
		#region Properties
		public int Id { get; set; } // Primary key for this profile
		public string CompanyName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;

		#endregion

		#region Relations
		// Foreign key back to the ApplicationUser
		[ForeignKey(nameof(AppUser))]
		public string AppUserId { get; set; } = default!;
		public AppUser AppUser { get; set; } = default!;

		#region Posts relation
		// Navigation property for the jobs posted by this company
		public ICollection<Job> Jobs { get; set; } = new HashSet<Job>(); // for one-to-many relationship 
		#endregion

		#endregion

	}
}
