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
	public class UserAcquiredSkills
	{
		[Key]
		public string UserEmail { get; set; } = null!;
		public DateTimeOffset AcquiredAt { get; set; } = DateTimeOffset.Now;
		public Proficiency Level { get; set; }

		#region Relations
		public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
		#endregion
	}
}
