using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	public enum ApplicationStatus
	{
		// The order of these values is important for the application logic
		Applied,
		Interview,
		Hired,
		Rejected,
		Withdrawn
	}
}
