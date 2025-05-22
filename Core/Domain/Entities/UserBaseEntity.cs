using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class UserBaseEntity : BaseEntity<Guid>
	{
		public string UserEmail { get; set; } = default!;
	}
}
