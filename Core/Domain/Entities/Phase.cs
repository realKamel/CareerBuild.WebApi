using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Phase
	{
		public int Id { get; set; }
		public string Name { get; set; } = default!;
		public string? Description { get; set; }
		public bool IsPassed { get; set; }
		public TimeOnly EstimatedDuration { get; set; }


		#region Relations
		#region Track relation
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;
		#endregion

		#region Exam relation
		public int ExamId { get; set; }
		public Exam Exam { get; set; } = default!;
		#endregion

		#region Course relations
		public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
		#endregion

		#region UserPassedPhases
		public ICollection<UserPassedPhases> UserPassedPhases { get; set; } = new HashSet<UserPassedPhases>();
		#endregion

		#region PhaseProvidedSkills
		public ICollection<PhaseProvidedSkills> PhaseProvidedSkills { get; set; } = new HashSet<PhaseProvidedSkills>();
		#endregion
		#endregion
	}
}
