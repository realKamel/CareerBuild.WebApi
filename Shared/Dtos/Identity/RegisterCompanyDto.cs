using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
	public class RegisterCompanyDto
	{
		[Range(1, 255)]
		public string CompanyName { get; set; } = default!;
		public string UserName { get; set; } = default!;
		public string Size { get; set; } = default!;
		public string Industry { get; set; } = default!;
		public string WebsiteUrl { get; set; } = default!;
		public AddressDto Address { get; set; } = default!;
		public string? PictureUrl { get; set; } = default!;


		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = default!;

		public string Password { get; set; } = default!;

		[Phone]
		public string? PhoneNumber { get; set; }
	}
}
