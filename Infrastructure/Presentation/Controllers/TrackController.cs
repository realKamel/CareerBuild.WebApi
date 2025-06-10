using AbstractServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Dtos.IdentityModule.Login;
using Shared.Dtos.TrackModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TracksController(IServiceManager _serviceManager) : ControllerBase
	{
		[HttpGet()]
		public async Task<ActionResult<IEnumerable<TrackDto>>> GetAllTracks(string? searchWord)
		{
			var tracks = await _serviceManager.TrackServices.GetAllTracks(searchWord);
			return Ok(tracks);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<DetailedTrackDto>>> GetTrackById(int id)
		{
			var tracks = await _serviceManager.TrackServices.GetTrackById(id);
			return Ok(tracks);
		}

		[Authorize]
		[HttpGet("enrolled")]
		public async Task<ActionResult<IEnumerable<UserTracksDto>>> GetUserEnrolledTracks()
		{
			var userEmail = User.FindFirstValue(ClaimTypes.Email);
			var tracks = await _serviceManager.TrackServices.GetUserEnrolledTracks(userEmail);
			return Ok(tracks);
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteTrack(int id)
		{
			var result = await _serviceManager.TrackServices.DeleteTrack(id);

			return Ok(result);
		}
	}
}
