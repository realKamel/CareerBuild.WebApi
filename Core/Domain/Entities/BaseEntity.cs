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
		public TKey Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; } = false;
		public string? DeletedBy { get; set; } 
		public DateTime? DeletedAt { get; set; } 
		public string? CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
