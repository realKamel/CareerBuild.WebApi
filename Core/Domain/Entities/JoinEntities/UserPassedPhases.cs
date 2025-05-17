using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserPassedPhases
	{
		[Key]
		public string UserEmail { get; set; } = default!;
		public DateTime StartedAt { get; set; } = DateTime.UtcNow;
		public DateTime? FinishedAt { get; set; } = null;
		public bool IsPassed { get; set; } = false;

		#region Relations
		public ICollection<Phase> Phases { get; set; } = new HashSet<Phase>();
		#endregion
	}
}
