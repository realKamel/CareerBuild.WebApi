using Shared.Dtos.SkillModule;

namespace Shared.Dtos;

public class PhaseDto : BaseDto
{
	public int EstimatedDurationInHours { get; set; }

	public ExamDto? Exam { get; set; }
	public ICollection<CourseDto>? Courses { get; set; }

	public ICollection<SkillDto>? Skills { get; set; }
}