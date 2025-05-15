using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Exam
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; } = null!;
		public decimal PassingScore { get; set; }
		public decimal ExamScore { get; set; }
		public int DurationInMinutes { get; set; }
		public int MaxAttempts { get; set; }
		public string? ExamLink { get; set; }

		#region Relations
		#region MyRegion
		public int PhaseId { get; set; }
		public Phase Phase { get; set; } = default!;
		#endregion
		#region Skills Relations
		public ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
		#endregion

		#region UserEnteredExams Relations
		public ICollection<UserEnteredExams> UserEnteredExams { get; set; } = new HashSet<UserEnteredExams>();
		#endregion

		#endregion
	}
}
