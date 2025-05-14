using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity
{
	public class LoggedInCompanyDto : LoggedIn
	{
		public CompanyProfileDto CompanyProfile { get; set; } = default!;
	}
}
