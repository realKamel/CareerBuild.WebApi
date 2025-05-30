using System.Security.Claims;
using AbstractServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.JobModule;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IServiceManager _serviceManager) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<JobDto>> GetAllJobs(string? searchWord)
	{
		var result = await _serviceManager.JobService.GetAllJobs(searchWord);
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<JobDto>> GetbyIdJobs(int id)
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
	[HttpPost("Update/{id}")]
	[au]
    public async Task<IActionResult> UpdateJob(int id, CreatedJobDto updatedJobDto)
    {
        var companyEmail = User.FindFirstValue(ClaimTypes.Email);
		var result = await _serviceManager.JobService.UpdateJob(id, updatedJobDto,companyEmail);
		return Ok(result);
	}

	[HttpDelete("Delete/{id}")]
	public async Task<ActionResult> DeleteJob(int id)
	{
		var result = await _serviceManager.JobService.DeletePost(id);
		return Ok(result);
	}
}