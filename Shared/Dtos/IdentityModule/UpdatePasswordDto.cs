using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.IdentityModule
{
	public class UpdatePasswordDto
	{
		[DataType(DataType.Password)] public string OldPassword { get; set; } = string.Empty;

		[DataType(DataType.Password)] public string NewPassword { get; set; } = string.Empty;
	}
}
