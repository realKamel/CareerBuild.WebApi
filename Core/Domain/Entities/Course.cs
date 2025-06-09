using Domain.Entities.Common;
using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Course : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
		public int CourseOrderInTrack { get; set; }
		public string? CourseUrl { get; set; } // optional
		public string? CoverUrl { get; set; } // optional
		public int DurationInHours { get; set; }
		public string? ProviderName { get; set; }
		public DifficultyLevel DifficultyLevel { get; set; }



		#region Relations
		#region Skills
		public ICollection<Skill>? Skills { get; set; } = new HashSet<Skill>();
		#endregion

		#region Phase Relation
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;
		#endregion

		#region UserCourses
		public ICollection<UserCourses> UserCourses { get; set; } = new HashSet<UserCourses>();
		#endregion
		#endregion
	}
}
