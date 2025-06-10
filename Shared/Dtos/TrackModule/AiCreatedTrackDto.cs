using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Common;
using Shared.Dtos.SkillModule;

namespace Shared.Dtos.TrackModule;

public class AiCreatedTrackDto
{
	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public required string Name { get; set; }//

	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public List<string> Details { get; set; }

	public required List<AiCreatedCourseDto> Courses { get; set; }

	// public required List<CreatedSkillDto> Skills { get; set; }

	// public string URL { get; set; }
	public string? CoverUrl { get; set; } // optional
	public string? difficultyLevel { get; set; }//
	public string prerequisite { get; set; }
	public string providerName { get; set; }
	public string trackImgURL { get; set; } // will be coverUrl
}
