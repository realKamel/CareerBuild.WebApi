namespace Shared.Dtos.TrackModule;

public class TrackDto : BaseDto
{
	public int EstimatedDurationInHours { get; set; }
	public string DifficultyLevel { get; set; } = null!;

	public ICollection<PhaseDto> Phases { get; set; } = new HashSet<PhaseDto>();

	public ICollection<TrackPrerequisitesDto>? TrackPrerequisites { get; set; }
}