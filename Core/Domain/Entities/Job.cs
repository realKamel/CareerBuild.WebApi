using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Job : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
		public Address Location { get; set; } = null!;
		public DateTime? ExpiresAt { get; set; } // this is optional
		public EmploymentType EmploymentType { get; set; }

		//Represent salary range
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }

		public string CompanyEmail { get; set; } = null!;

		#region Relations
		public ICollection<JobRequiredSkills> JobRequiredSkills { get; set; } = new HashSet<JobRequiredSkills>();
		#endregion
	}
}
