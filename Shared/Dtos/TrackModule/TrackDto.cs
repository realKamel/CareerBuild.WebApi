namespace Shared.Dtos.TrackModule;

public class TrackDto : BaseDto
{
	public string DifficultyLevel { get; set; } = null!;
	public string? CoverUrl { get; set; }
	public string? ProviderName { get; set; }
}