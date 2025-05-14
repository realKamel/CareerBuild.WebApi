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

		[HttpPost("CompanyUser")]
		public async Task<ActionResult<LoggedInCompany>> CompanyLogin(LoginDto login)
		{
			var result = await _serviceManager
				.AuthenticationServices.LoginCompanyAsync(login);
			return Ok(result);
		}

		[HttpPost("SignUpRegularUser")]
		public async Task<ActionResult<bool>> RegisterRegularUserAsync(RegisterUserDto userDto)
		{
			var result = await _serviceManager.AuthenticationServices.RegisterRegularUserAsync(userDto);
			return Ok(result);
		}

		[HttpPost("SignUpCompanyUser")]
		public async Task<ActionResult<bool>> RegisterCompanyUserAsync(RegisterCompanyDto userDto)
		{
			var result = await _serviceManager.AuthenticationServices
				.RegisterCompanyUserAsync(userDto);
			return Ok(result);
		}
	}
}
