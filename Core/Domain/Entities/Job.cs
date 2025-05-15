using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Job
	{
		public int JobId { get; set; }
		public string JobTitle { get; set; } = null!;
		public string Description { get; set; } = null!;
		public Address JobLocation { get; set; } = null!;
		public DateTime PostedAt { get; set; }
		public DateTime? ExpiresAt { get; set; } // this is optional
		public EmploymentType EmploymentType { get; set; }

		//Represent salary range
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }
	}
}
