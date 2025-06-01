using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.SkillModule;

namespace Shared.Dtos
{
	public class ExamDto : BaseDto
	{
		public decimal PassingScore { get; set; }
		public decimal ExamScore { get; set; }
		public int DurationInMinutes { get; set; }
		public int MaxAttempts { get; set; }
		public string? ExamLink { get; set; }

		public ICollection<SkillDto> Skills { get; set; }
	}
}
