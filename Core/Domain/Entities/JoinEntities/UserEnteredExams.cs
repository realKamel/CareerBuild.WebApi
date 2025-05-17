using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserEnteredExams
	{
		[Key]
		public string UserEmail { get; set; } = default!;
		public int AttemptCount { get; set; } = 1;
		public DateTime? LastAttemptDate { get; set; } = null;
		public DateTime StartedAt { get; set; } = DateTime.UtcNow;
		public DateTime? FinishedAt { get; set; } = null;
		public decimal Score { get; set; }
		public bool IsPassed { get; set; } = false;
		#region Relations
		public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
		#endregion
	}
}
