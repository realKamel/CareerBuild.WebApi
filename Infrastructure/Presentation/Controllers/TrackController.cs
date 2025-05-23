using AbstractServices;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.TrackModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route( "api/[controller]" )]
	public class TrackController(IServiceManager _serviceManager) : ControllerBase
	{
		[HttpGet()]
		public async Task<ActionResult<IEnumerable<TrackDto>>> GetAllTracks( )
		{
			var tracks = await _serviceManager.TrackServices.GetAllTracks();
			return Ok( tracks );
		}
		[HttpGet( "{id}" )]
		public async Task<ActionResult<IEnumerable<TrackDto>>> GetTrackById(int id)
		{
			var tracks = await _serviceManager.TrackServices.GetTrackById( id );
			return Ok( tracks );
		}
	}
}
