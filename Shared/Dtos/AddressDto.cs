using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
	public class AddressDto
	{
		public string Street { get; set; } = default!;
		public string City { get; set; } = default!;
		public string Country { get; set; } = default!;
	}
}
