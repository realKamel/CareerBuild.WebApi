using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.IdentityModule
{
	public class AppUser : AppUserBase
	{
		/*
		 * uq_user_email constraint
		 */

		public string FirstName { get; set; } = default!;
		public string LastName { get; set; } = default!;
		public string? PreferredJobTitle { get; set; } = default!;
		public string? ResumeUrl { get; set; } = default!;
		public string UserGoal { get; set; } = default!;
		public EducationLevel EducationLevel { get; set; }
	}
}
