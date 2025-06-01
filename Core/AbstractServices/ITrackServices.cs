using Shared.Dtos;
using Shared.Dtos.TrackModule;

namespace AbstractServices;

public interface ITrackServices
{
	public Task<TrackDto> GetTrackById(int trackId);
	public Task<IEnumerable<TrackDto>> GetAllTracks(string? searchWord);
	public Task<IEnumerable<UserTracksDto>> GetUserEnrolledTracks(string? userEmail);
}