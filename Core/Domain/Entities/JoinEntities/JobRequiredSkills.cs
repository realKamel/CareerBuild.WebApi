using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class JobRequiredSkills
	{
		public Proficiency RequiredProficiency { get; set; } = default!;
		// the proficiency level required for the skill
		public bool IsMandatory { get; set; } = true; // true if the skill is mandatory, false if it is optional
		#region Relations
		public int JobId { get; set; }
		public Job Job { get; set; } = default!;

		public int SkillId { get; set; }
		public Skill Skill { get; set; } = default!;
		#endregion
	}
}
