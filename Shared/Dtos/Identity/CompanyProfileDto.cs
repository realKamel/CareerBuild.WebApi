using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
	public class CompanyProfileDto
	{
		public string CompanyName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;
	}
}
