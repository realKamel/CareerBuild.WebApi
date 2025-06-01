using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class BaseEntity<TKey>
	{
		[Key] public TKey Id { get; set; }
		public string? CreatedBy { get; set; }
		public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
		public string? DeletedBy { get; set; }
		public DateTimeOffset? DeletedAt { get; set; }
		public string? UpdatedBy { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
		public bool IsDeleted { get; set; } = false;
	}
}
