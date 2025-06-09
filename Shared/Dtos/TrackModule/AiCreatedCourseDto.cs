using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Common;

namespace Shared.Dtos.TrackModule;

public class AiCreatedCourseDto
{
	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public required string Name { get; set; }


	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string? Description { get; set; } = null!; // required


	public string Duration { get; set; }


	public List<string> Skills { get; set; }


	public string URL { get; set; }


	//TODO: ai api should return this
	public decimal Price { get; set; }
	public string? ProviderName { get; set; }
	public DifficultyLevelDto DifficultyLevel { get; set; }
	public int? Phase { get; set; }
}
