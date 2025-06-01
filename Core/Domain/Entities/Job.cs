using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Job : BaseEntity<int>
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public Address Location { get; set; } = null!;
		public DateTime? ExpiresAt { get; set; } // this is optional
		public EmploymentType EmploymentType { get; set; }

		//Represent salary range
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }

		public required string CompanyEmail { get; set; }

		#region Relations

		public ICollection<Skill>? Skills { get; set; } = new HashSet<Skill>();

		public ICollection<UserJobs>? UserJobs { get; set; } = new HashSet<UserJobs>();

		#endregion
	}
}
