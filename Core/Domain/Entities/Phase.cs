using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Phase : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
		public int EstimatedDurationInHours { get; set; }

		#region Relations
		#region Track relation
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;
		#endregion

		#region Exam relation
		public int? ExamId { get; set; }
		public Exam? Exam { get; set; } = default!;
		#endregion

		#region Course relations
		public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
		#endregion

		#region PhaseProvidedSkills
		public ICollection<PhaseSkills>? PhaseSkills { get; set; } = new HashSet<PhaseSkills>();
		#endregion

		public ICollection<UserPhases>? UserPhases { get; set; } = new HashSet<UserPhases>();
		#endregion
	}
}
