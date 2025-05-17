using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity.Login
{
	public class LoggedInUserDto : LoggedInBase
	{
		public string FirstName { get; set; } = default!;
		public string LastName { get; set; } = default!;
		public string? PreferredJobTitle { get; set; } = default!;
		public string? ResumeUrl { get; set; } = default!;
		public string UserGoal { get; set; } = default!;
		public string EducationLevel { get; set; } = default!;
	}
}
