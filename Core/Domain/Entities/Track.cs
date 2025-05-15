using Domain.Entities.Common;
using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Track
	{
		[Key]
		public int TrackId { get; set; }
		public string Name { get; set; } = null!; // required
		public string Description { get; set; } = null!; // required
		public TimeOnly EstimatedDuration { get; set; }
		public DifficultyLevel DifficultyLevel { get; set; }
		#region Relations
		public ICollection<TrackPrerequisites>? TrackPrerequisites { get; set; }
		public ICollection<Phase> Phases { get; set; } = new HashSet<Phase>();
		public ICollection<UserEnrolledTracks> UserEnrolledTracks { get; set; } = new HashSet<UserEnrolledTracks>();
		#endregion
	}
}
