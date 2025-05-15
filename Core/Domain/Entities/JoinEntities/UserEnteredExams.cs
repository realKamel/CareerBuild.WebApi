using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserEnteredExams
	{
		public int MaxAttemptCount { get; set; } = 2;
		public int AttemptCount { get; set; } = 0;
		public DateTime? LastAttemptDate { get; set; } = null;
		public DateTime StartedAt { get; set; } = DateTime.UtcNow;
		public DateTime? FinishedAt { get; set; } = null;
		public decimal Score { get; set; }
		public bool IsPassed { get; set; } = false;
		#region Relations
		public int UserId { get; set; }
		public RegularUserProfile User { get; set; } = default!;

		public int ExamId { get; set; }
		public Exam Exam { get; set; } = default!;
		#endregion
	}
}
