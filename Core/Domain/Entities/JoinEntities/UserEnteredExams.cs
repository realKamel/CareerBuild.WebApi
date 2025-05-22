using Domain.Entities.IdentityModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.JoinEntities
{
	public class UserEnteredExam : UserBaseEntity
	{
		public int AttemptCount { get; set; } = 1;
		public DateTime? LastAttemptDate { get; set; } = null;
		public DateTime? FinishedAt { get; set; } = null;
		public decimal Score { get; set; }
		public bool IsPassed { get; set; } = false;
		#region Relations
		public Exam Exams { get; set; } = default!;
		#endregion
	}
}
