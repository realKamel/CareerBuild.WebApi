using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using AbstractServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.JobModule;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IServiceManager _serviceManager) : ControllerBase
{
	[HttpGet] // Get api/Jobs 
			  //get all jobs for everyone
	public async Task<ActionResult<JobDto>> GetAllJobs(string? searchWord)
	{
		var result = await _serviceManager.JobService.GetAllJobs(searchWord);
		return Ok(result);
	}

	[HttpGet("{id}")] // Get api/Job/id
	public async Task<ActionResult<JobDto>> GetByIdJobs(int id)
	{
		var result = await _serviceManager.JobService.GetJobById(id);
		return Ok(result);
	}

	[Authorize]
	[HttpPost]
	public async Task<ActionResult<JobDto>> CreateJobPost(CreatedJobDto createdJobDto)
	{
		var companyEmail = User.FindFirstValue(ClaimTypes.Email);
		var result = await _serviceManager.JobService.CreatedJob(createdJobDto, companyEmail);
		return Ok(result);
	}

	[HttpPatch("{id}")]
	[Authorize]
	public async Task<IActionResult> UpdateJob(int id, CreatedJobDto updatedJobDto)
	{
		var companyEmail = User.FindFirstValue(ClaimTypes.Email);
		var result = await _serviceManager.JobService.UpdateJob(id, updatedJobDto, companyEmail);
		return Ok(result);
	}

	[Authorize]
	[HttpDelete("{id}")]
	public async Task<ActionResult<bool>> DeleteJobPost(int id)
	{
		var result = await _serviceManager.JobService.DeletePost(id);
		return Ok(result);
	}

	[Authorize]
	[HttpGet("CompanyPosts")] // GET api/Job/CompanyPosts
	public async Task<ActionResult<IEnumerable<JobDto>>> GetCompanyPostedJobs(string? searchWord)
	{
		var companyEmail = User.FindFirstValue(ClaimTypes.Email);
		var result = await _serviceManager.JobService.GetCompanyPostedJobs(searchWord, companyEmail);
		return Ok(result);
	}
}