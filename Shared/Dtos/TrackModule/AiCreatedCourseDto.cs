using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Common;
using Shared.Dtos.SkillModule;

namespace Shared.Dtos.TrackModule;

public class AiCreatedCourseDto
{
	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public required string Name { get; set; }


	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string? Description { get; set; } = null!; // required

	public int orderInTrack { get; set; }
	public string coverUrl { get; set; }
	public string URL { get; set; }
	public int DurationInHours { get; set; }
	public string courseDifficulty { get; set; } // will be DifficultyLevel 

	public List<string> Skills { get; set; }
}
