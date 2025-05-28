using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserSkills : UserBaseEntity
	{
		public Proficiency Level { get; set; }

		#region Relations
		public int SkillId { get; set; } 
		public Skill Skill { get; set; } = default!;
		#endregion
	}
}
