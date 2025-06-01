using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.TrackModule;

public class TrackPrerequisitesDto
{
	public TrackDto Track { get; set; } = default!;

	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public string PrerequisiteName { get; set; } = default!;

	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string PrerequisiteDescription { get; set; } = default!;
}