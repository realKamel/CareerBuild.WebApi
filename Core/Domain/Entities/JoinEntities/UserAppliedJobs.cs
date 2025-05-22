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
	public class UserAppliedJobs : BaseEntity<Guid>
	{
		public string UserEmail { get; set; } = null!;
		public ICollection<Job> Jobs { get; set; } = new HashSet<Job>();
		public ApplicationStatus ApplicationStatusStatus { get; set; }
	}
}
