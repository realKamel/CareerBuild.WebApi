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
	public class Skill : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
		public SkillCategory? Category { get; set; }

		#region Relations
		#region Exam Relation
		public int ExamID { get; set; }
		public Exam Exam { get; set; } = default!;
		#endregion

		#region Course Relation
		public int CourseID { get; set; }
		public Course Course { get; set; } = default!;
		#endregion

		#region JobRequiredSkills relations
		public ICollection<JobRequiredSkills> JobRequiredSkills { get; set; } = new HashSet<JobRequiredSkills>();
		#endregion

		#region PhaseProvidedSkills relations
		public ICollection<PhaseProvidedSkills> PhaseProvidedSkills { get; set; } = new HashSet<PhaseProvidedSkills>();
		#endregion
		#endregion
	}
}
