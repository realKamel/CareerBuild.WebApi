using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserEnrolledTracks
	{
		public DateTimeOffset StartedAt { get; set; } = DateTime.Now;
		public DateTimeOffset? FinishedAt { get; set; } = null;
		public bool IsFinished { get; set; } = false;
		public EnrollmentStatus EnrollmentStatus { get; set; }
		#region Relations
		public int UserId { get; set; }
		public RegularUserProfile User { get; set; } = default!;
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!; 
		#endregion
	}
}
