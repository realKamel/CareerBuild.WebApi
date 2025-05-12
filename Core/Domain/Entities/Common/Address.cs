using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	[Owned]
	public class Address
	{
		public string Street { get; set; } = default!;
		public string City { get; set; } = default!;
		public string Country { get; set; } = default!;
	}
}
