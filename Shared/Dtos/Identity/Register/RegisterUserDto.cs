using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity.Register
{
	public class RegisterUserDto : RegisterBaseDto
	{
		//[Range(1,255)]
		public string FirstName { get; set; } = default!;

		//[Range(1, 255)]
		public string LastName { get; set; } = default!;

		[MaxLength(255)]
		public string? PreferredJobTitle { get; set; } = default!;

		public string? ResumeUrl { get; set; } = default!;

		public string UserGoal { get; set; } = default!;

		public string EducationLevel { get; set; } = default!;
	}
}
