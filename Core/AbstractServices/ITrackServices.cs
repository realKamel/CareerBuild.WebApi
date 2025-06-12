using Shared.Dtos;
using Shared.Dtos.TrackModule;

namespace AbstractServices;

public interface ITrackServices
{
	public Task<DetailedTrackDto> GetTrackById(int trackId);
	public Task<TrackDto> SearchTrackByAi(string searchWord);
	public Task<IEnumerable<TrackDto>> GetAllTracks();
	public Task<IEnumerable<UserTracksDto>> GetUserEnrolledTracks(string? userEmail);
	public Task<bool> DeleteTrack(int trackId);
}