using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
	public class RegisterBaseDto
	{
		public string UserName { get; set; } = default!;
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
