using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	public enum EnrollmentStatus
	{
		NotStarted = 0,
		Enrolled = 1,
		InProgress = 2,
		Completed = 3,
		DroppedOut = 4,
		// Add more statuses as needed
	}
}
