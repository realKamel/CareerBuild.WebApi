using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Identity.Login
{
	public class LoggedInCompanyDto : LoggedInBase
	{
		public CompanyProfileDto Profile { get; set; } = default!;
	}
}
