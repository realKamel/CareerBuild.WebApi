using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;
using Domain.Entities.JoinEntities;

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

		#region Course Relation
		public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();

		#endregion

		#region JobRequiredSkills relations

		public ICollection<Job>? Jobs { get; set; } = new HashSet<Job>();

		#endregion

		public ICollection<UserSkills>? UserSkills { get; set; } = new HashSet<UserSkills>();

		#endregion
	}
}
