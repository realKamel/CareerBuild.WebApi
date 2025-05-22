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
		[Key] 
		public TKey Id { get; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public bool IsDeleted { get; set; } = false;
		public string? DeletedBy { get; set; } = null;
		public DateTime? DeletedAt { get; set; } = null;
		public string? CreatedBy { get; set; } = null;
		public string? UpdatedBy { get; set; } = null;
		public DateTime? UpdatedAt { get; set; } = null;
	}
}
