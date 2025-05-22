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
	public class UserAcquiredSkills : BaseEntity<Guid>
	{
		public string UserEmail { get; set; } = default!;
		public Proficiency Level { get; set; }

		#region Relations
		public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
		#endregion
	}
}
