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
	public class RegularUserProfile
	{
		/*
		 * uq_user_email constraint
		 */
		#region Properties
		public int Id { get; set; } // Primary key for profile
		public string FirstName { get; set; } = default!;
		public string LastName { get; set; } = default!;
		public string? PreferredJobTitle { get; set; } = default!;
		public string? ResumeUrl { get; set; } = default!;
		public string UserGoal { get; set; } = default!;
		public EducationLevel EducationLevel { get; set; }
		#endregion

		#region Relations
		[ForeignKey(nameof(AppUser))]
		public string AppUserId { get; set; } = default!; // IdentityUser ID is string
		public AppUser AppUser { get; set; } = default!;
		#endregion
	}
}
