using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserPassedPhases
	{
		public DateTime StartedAt { get; set; } = DateTime.UtcNow;
		public DateTime? FinishedAt { get; set; } = null;
		public bool IsPassed { get; set; } = false;
		public bool IsCompleted { get; set; } = false;

		#region Relations
		public int UserId { get; set; }
		public RegularUserProfile User { get; set; } = default!;

		public int PhaseId { get; set; }
		public Phase Phase { get; set; } = default!;
		#endregion
	}
}
