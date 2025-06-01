using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class PhaseSkills
	{
		public string RecommendationReason { get; set; } = null!;
		#region Relations
		public int PhaseId { get; set; }
		public Phase Phase { get; set; } = null!;

		public int SkillId { get; set; }
		public Skill Skill { get; set; } = null!; 
		#endregion
	}
}
