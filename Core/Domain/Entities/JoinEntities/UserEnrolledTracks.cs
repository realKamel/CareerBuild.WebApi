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
	public class UserEnrolledTracks : BaseEntity<Guid>
	{
		public string UserEmail { get; set; } = null!;
		public DateTimeOffset? FinishedAt { get; set; } = null;
		public bool IsFinished { get; set; } = false;
		public EnrollmentStatus EnrollmentStatus { get; set; }
		#region Relations
		public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
		#endregion
	}
}
