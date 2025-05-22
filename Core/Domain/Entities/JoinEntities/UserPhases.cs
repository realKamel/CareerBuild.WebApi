using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserPhases
	{
		public string UserEmail { get; set; } = default!;

		public DateTime? FinishedAt { get; set; } = null;
		public bool IsPassed { get; set; } = false;

		#region Relations
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;

		public int PhaseId { get; set; }
		public Phase Phase { get; set; } = default!;
		#endregion
	}
}
