using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Exam : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required
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
		public ICollection<UserExam> UserEnteredExams { get; set; } = new HashSet<UserExam>();
		#endregion

		#endregion
	}
}
