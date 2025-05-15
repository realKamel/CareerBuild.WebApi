using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	public enum EmploymentType : byte
	{
		none = 0,
		FullTime = 1,
		PartTime = 2,
		Contract = 3,
	}
}
