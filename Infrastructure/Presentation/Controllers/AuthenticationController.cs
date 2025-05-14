using AbstractServices;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
	{
		[HttpPost("RegularUser")]
		public async Task<ActionResult<LoggedInUser>> RegularUserLogin(LoginDto login)
		{
			var result = await _serviceManager
				.AuthenticationServices.LoginRegularUserAsync(login);
			return Ok(result);
		}
	}
}
