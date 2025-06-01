using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.IdentityModule.Register
{
	public class RegisterBaseDto
	{
		[Required(ErrorMessage = "Username is required")]
		[StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
		public string UserName { get; set; } = default!;

		public AddressDto Address { get; set; } = default!;

		public string? PictureUrl { get; set; } = default!;


		[Required(ErrorMessage = "Email is required")]
		[StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
		[RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
		public string Email { get; set; } = default!;

		[Required(ErrorMessage = "Password is required")]
		[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
		public string Password { get; set; } = default!;


		[Phone]
		public string? PhoneNumber { get; set; }
	}
}
