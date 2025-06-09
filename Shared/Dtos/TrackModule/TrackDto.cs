namespace Shared.Dtos.TrackModule;

public class TrackDto : BaseDto
{
	public int DurationInHours { get; set; }
	public string DifficultyLevel { get; set; } = null!;
	public string? CoverUrl { get; set; }
}