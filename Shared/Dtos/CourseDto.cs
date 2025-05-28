using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
	public class CourseDto : BaseDto
	{
		public decimal Price { get; set; }
		public string? CourseUrl { get; set; } // optional
		public int DurationInHours { get; set; }
		public string? ProviderName { get; set; }
		public string? DifficultyLevel { get; set; }
		public ICollection<SkillDto>? Skills { get; set; } = new HashSet<SkillDto>();
	}
}
