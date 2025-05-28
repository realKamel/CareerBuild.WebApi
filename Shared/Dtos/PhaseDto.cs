using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos;

public class PhaseDto : BaseDto
{
	public int EstimatedDurationInHours { get; set; }

	public ExamDto? Exam { get; set; }
	public ICollection<CourseDto>? Courses { get; set; } = new HashSet<CourseDto>();

	public ICollection<SkillDto>? Skills { get; set; } = new HashSet<SkillDto>();
}