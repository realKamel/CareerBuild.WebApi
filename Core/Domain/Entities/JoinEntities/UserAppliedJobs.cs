using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserAppliedJobs
	{
		public int UserId { get; set; }
		public RegularUserProfile User { get; set; } = default!;

		public int JobId { get; set; }
		public Job Job { get; set; } = default!;

		public DateTime AppliedAt { get; set; } = DateTime.Now;
		public ApplicationStatus ApplicationStatusStatus { get; set; }
	}
}
