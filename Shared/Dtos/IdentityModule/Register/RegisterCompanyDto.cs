using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.IdentityModule.Register
{
	public class RegisterCompanyDto : RegisterBaseDto
	{
		[Required(ErrorMessage = "companyName is Required")]
		[StringLength(20, ErrorMessage = "Must be between 3 and 20 characters", MinimumLength = 3)]
		public string CompanyName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;
	}
}
