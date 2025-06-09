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
		Applied = 0,
		Interview = 1,
		Hired = 3,
		Rejected = 4,
		Withdrawn = 5
	}
}
