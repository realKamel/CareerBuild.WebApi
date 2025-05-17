using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserAppliedJobs
	{
		[Key]
		public string UserEmail { get; set; } = default!;
		public ICollection<Job> Jobs { get; set; } = new HashSet<Job>();
		public DateTime AppliedAt { get; set; } = DateTime.Now;
		public ApplicationStatus ApplicationStatusStatus { get; set; }
	}
}
