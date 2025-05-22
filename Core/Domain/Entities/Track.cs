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
	public class Track : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
		public TimeOnly EstimatedDuration { get; set; }
		public DifficultyLevel DifficultyLevel { get; set; }


		#region Relations

		public ICollection<TrackPrerequisites>? TrackPrerequisites { get; set; }
			= new HashSet<TrackPrerequisites>();

		public ICollection<Phase> Phases { get; set; } = new HashSet<Phase>();

		#endregion
	}
}