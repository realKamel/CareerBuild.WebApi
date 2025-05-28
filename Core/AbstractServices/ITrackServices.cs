using Shared.Dtos.TrackModule;

namespace AbstractServices;

public interface ITrackServices
{
	public Task<TrackDto> GetTrackById(int trackId);
	public Task<IEnumerable<TrackDto>> GetAllTracks(string? searchWord);
}