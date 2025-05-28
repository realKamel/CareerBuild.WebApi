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
		[MaxLength(255, ErrorMessage = "UserEmail cannot be longer than 255 characters.")]
		public string UserEmail { get; set; } = null!;

		public DateTime? FinishedAt { get; set; }
		public bool IsPassed { get; set; } = false;

		#region Relations

		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;

		public int PhaseId { get; set; }
		public Phase Phase { get; set; } = default!;

		#endregion
	}
}