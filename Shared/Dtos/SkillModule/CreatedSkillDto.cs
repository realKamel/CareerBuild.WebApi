using System.ComponentModel.DataAnnotations;
using Domain.Entities.Common;

namespace Shared.Dtos.SkillModule;

public class CreatedSkillDto
{
	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public required string Name { get; set; }

	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string? Description { get; set; }

	public SkillCategory Category { get; set; }
}
