using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Common;

namespace Shared.Dtos.TrackModule;

public class DetailedTrackDto : BaseDto
{
	public required string CreatedBy { get; set; }

	public int DurationInHours { get; set; }

	public DifficultyLevelDto DifficultyLevel { get; set; }

	public string? CoverUrl { get; set; } // optional

	public ICollection<CourseDto>? Courses { get; set; }

	public ICollection<TrackPrerequisitesDto>? TrackPrerequisites { get; set; }
}