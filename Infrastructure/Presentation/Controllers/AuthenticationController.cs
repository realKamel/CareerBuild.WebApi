using AbstractServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Identity.Login;
using Shared.Dtos.Identity.Register;
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
	public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
	{
		[HttpPost("RegularUser")]
		public async Task<ActionResult<LoggedInUserDto>> RegularUserLogin(LoginDto login)
		{
			var result = await _serviceManager
				.AuthenticationServices.LoginRegularUserAsync(login);
			return Ok(result);
		}

		[HttpPost("CompanyUser")]
		public async Task<ActionResult<LoggedInCompanyDto>> CompanyLogin(LoginDto login)
		{
			var result = await _serviceManager
				.AuthenticationServices.LoginCompanyAsync(login);
			return Ok(result);
		}

		[HttpPost("RegisterRegularUser")]
		public async Task<ActionResult<bool>> RegisterRegularUserAsync(RegisterUserDto userDto)
		{
			var result = await _serviceManager.AuthenticationServices.RegisterRegularUserAsync(userDto);
			return Ok(result);
		}

		[HttpPost("RegisterCompany")]
		public async Task<ActionResult<bool>> RegisterCompanyUserAsync(RegisterCompanyDto userDto)
		{
			var result = await _serviceManager.AuthenticationServices
				.RegisterCompanyUserAsync(userDto);
			return Ok(result);
		}
		[Authorize]
		[HttpDelete("DeleteUser")]
		public async Task<ActionResult<bool>> DeleteUser()
		{
			var email = User.FindFirstValue(ClaimTypes.Email);

			var result = await _serviceManager.AuthenticationServices.DeleteUser(email);

			return Ok(result);
		}

		[Authorize]
		[HttpPut("UpdatePassword")]
		public async Task<ActionResult<bool>> UpdatePassword(string oldPassword, string newPassword)
		{
			var email = User.FindFirstValue(ClaimTypes.Email);

			var result = await _serviceManager.AuthenticationServices
				.UpdatePassword(email, oldPassword, newPassword);

			return Ok(result);
		}
	}
}
