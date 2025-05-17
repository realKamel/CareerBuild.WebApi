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
	public class Skill
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public SkillCategory? Category { get; set; }
		public string? Description { get; set; }

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
