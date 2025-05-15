using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserAcquiredSkills
	{

		public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;
		public Proficiency Level { get; set; }
		#region Relations
		public int UserId { get; set; }
		public RegularUserProfile User { get; set; } = null!;
		public int SkillId { get; set; }
		public Skill Skill { get; set; } = null!;
		#endregion
	}
}
