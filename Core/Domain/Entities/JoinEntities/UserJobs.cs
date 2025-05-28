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
	public class UserJobs : UserBaseEntity
	{
		public int JobId { get; set; }
		public Job Job { get; set; } = default!;
		public ApplicationStatus ApplicationStatusStatus { get; set; }
	}
}
