using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
	public class LoggedInCompany
	{
		public string UserName { get; set; } = default!;
		public string CompanyName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Email { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;
		public AddressDto Address { get; set; } = default!;
		public string? PictureUrl { get; set; } = default!;
		public string Token { get; set; } = default!;
	}
}
