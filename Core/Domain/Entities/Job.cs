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
	public class Job
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public Address Location { get; set; } = null!;
		public DateTime PostedAt { get; set; }
		public DateTime? ExpiresAt { get; set; } // this is optional
		public EmploymentType EmploymentType { get; set; }

		//Represent salary range
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }

		[ForeignKey(nameof(Company))]
		public int CompanyId { get; set; }
		public CompanyUserProfile Company { get; set; } = null!;

		#region Relations
		public ICollection<JobRequiredSkills> JobRequiredSkills { get; set; } = new HashSet<JobRequiredSkills>();

		public ICollection<UserAppliedJobs> UserAppliedJobs { get; set; } = new HashSet<UserAppliedJobs>();
		#endregion
	}
}
