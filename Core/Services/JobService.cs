using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.IdentityModule;
using Domain.Entities.JoinEntities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services.Specifications;
using Shared.Dtos.JobModule;

namespace Services;

public class JobService(IUnitOfWork _unitOfWork, IMapper _mapper, UserManager<AppUser> _userManager) : IJobService
{
	public async Task<IEnumerable<JobDto>> GetAllJobs(string? searchWord)
	{
		var result = await _unitOfWork.GetRepository<Job, int>().GetAllAsync(new JobSpecification(searchWord, null));

		if (result == null)
		{
			throw new JobNotFoundException("No Jobs are Found");
		}

		return _mapper.Map<IEnumerable<Job>, IEnumerable<JobDto>>(result);
	}

	public async Task<JobDto> GetJobById(int id)
	{
		var job = await _unitOfWork.GetRepository<Job, int>()
						.GetByIdAsync(new JobSpecification(id, null));

		if (job == null)
		{
			throw new JobNotFoundException($"Job is not Found");
		}


		var company = await _userManager.FindByEmailAsync(job.CompanyEmail) as CompanyUser;

		if (company is null)
		{
			Log.Warning($"Company user with email {job.CompanyEmail} not found.");
			throw new UserNotFoundException("Company user not found. Please check your login credentials.");
		}
		// job.WebsiteUrl = company.WebsiteUrl;

		return _mapper.Map<Job, JobDto>(job);
	}

	public async Task<JobDto> CreatedJob(CreatedJobDto createdJobDto, string? companyEmail)
	{
		var job = _mapper.Map<CreatedJobDto, Job>(createdJobDto);


		companyEmail = "Orange@gmail.com";

		if (job is null || companyEmail is null)
		{
			throw new Exception("Error in Creating Post. Please Try Again Later");
		}

		var company = await _userManager.FindByEmailAsync(companyEmail) as CompanyUser;

		if (company is null)
		{
			throw new UnauthorizedAccessException("User is Not Logged In");
		}

		job.CompanyEmail = company?.Email;
		job.CompanyName = company.CompanyName;
		job.CompanyLogoUrl = company.PictureUrl;
		try
		{
			await _unitOfWork.GetRepository<Job, int>().AddAsync(job);
			await _unitOfWork.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Log.Error(e, "Error occurred while creating a job.");
			throw new("An error occurred while creating the job.", e);
		}

		var result = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(job.Id);

		if (result is null)
		{
			throw new JobNotFoundException($"No Job is Found");
		}

		return _mapper.Map<Job, JobDto>(result);
	}
	public async Task<JobDto> UpdateJob(int id, CreatedJobDto updatedJobDto, string? companyEmail)
	{
		var job = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(id);

		if (job is null)
		{
			throw new JobNotFoundException("Error While Update Job. The Job Is not Found");
		}

		var jobMapped = _mapper.Map(updatedJobDto, job);

		job.UpdatedAt = DateTimeOffset.UtcNow;
		job.UpdatedBy = companyEmail;

		if (updatedJobDto.Skills != null)
		{
			job.Skills = _mapper.Map<ICollection<Skill>>(updatedJobDto.Skills);
		}

		try
		{
			_unitOfWork.GetRepository<Job, int>().Update(jobMapped);
			await _unitOfWork.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			Log.Error(ex.Message, "Error Happen When Update Job");
			throw;
		}
		var result = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(jobMapped.Id);

		if (result is null)
		{
			throw new Exception("Cant Update Now Try Again Later");
		}
		return _mapper.Map<Job, JobDto>(result);
	}

	public async Task<bool> DeletePost(int id)
	{
		var repo = _unitOfWork.GetRepository<Job, int>();
		var job = await repo.GetByIdAsync(id);
		if (job is not null)
		{
			repo.Remove(job);
		}
		return await _unitOfWork.SaveChangesAsync() > 0;
	}

	public async Task<IEnumerable<JobDto>> GetCompanyPostedJobs(string? searchWord, string? email)
	{
		//email is null means that the user is not logged in and will always be one
		var jobList = await _unitOfWork.GetRepository<Job, int>()
		.GetAllAsync(new JobSpecification(searchWord, email));

		if (jobList is null || !jobList.Any())
		{
			throw new JobNotFoundException("There is no Posted Jobs");
		}

		if (email is null)
		{
			Log.Warning("Company email is null, user might not be logged in.");
			throw new UnauthorizedAccessException("User is not logged in");
		}

		var company = await _userManager.FindByEmailAsync(email) as CompanyUser;

		if (company is null)
		{
			Log.Warning($"Company user with email {email} not found.");
			throw new UserNotFoundException("Company user not found. Please check your login credentials.");
		}

		foreach (var job in jobList)
		{
			job.CompanyEmail = company.Email;
			job.CompanyName = company.CompanyName;
			job.CompanyLogoUrl = company.PictureUrl;
		}

		var mappedJobs = _mapper.Map<IEnumerable<Job>, IEnumerable<JobDto>>(jobList);

		if (mappedJobs is null)
		{
			throw new Exception("Internal Error");
		}
		return mappedJobs;
	}

	public async Task<IEnumerable<PostedJobApplication>> GetUserAppliedJobs(string? userEmail)
	{
		if (string.IsNullOrEmpty(userEmail))
		{
			Log.Warning("Company email is null or empty.");
			throw new UnauthorizedAccessException("User is not logged in");
		}

		var user = await _userManager.FindByEmailAsync(userEmail) as RegularUser;

		if (user is null)
		{
			Log.Warning($"User with email {userEmail} not found.");
			throw new UserNotFoundException("User not found. Please check your login credentials.");
		}


		var appliedJobs = await _unitOfWork.GetRepository<UserJobs, Guid>().GetAllAsync(new UserJobsSpecification());

		if (appliedJobs is null || !appliedJobs.Any())
		{
			Log.Warning($"No applied jobs found for user with email {userEmail}.");
			throw new JobNotFoundException("No applied jobs found for this user.");
		}

		var mappedJobs = _mapper.Map<IEnumerable<UserJobs>, IEnumerable<PostedJobApplication>>(appliedJobs);

		if (mappedJobs is null)
		{
			Log.Error("Mapping applied jobs to PostedJobApplication failed.");
			throw new Exception("Internal Error");
		}
		return mappedJobs;
	}

	public async Task<bool> ApplyForJob(int jobId, string? userEmail)
	{
		if (string.IsNullOrEmpty(userEmail))
		{
			Log.Warning("User email is null or empty.");
			throw new UnauthorizedAccessException("User is not logged in");
		}
		if (jobId <= 0)
		{
			Log.Warning($"Invalid job ID: {jobId}");
			throw new ArgumentException("Invalid job ID");
		}
		var user = _userManager.FindByEmailAsync(userEmail).Result as RegularUser;
		if (user is null)
		{
			Log.Warning($"User with email {userEmail} not found.");
			throw new UserNotFoundException("User not found. Please check your login credentials.");
		}
		var job = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(jobId);
		if (job is null)
		{
			Log.Warning($"Job with ID {jobId} not found.");
			throw new JobNotFoundException("Job not found. Please Try again later.");
		}
		if (job.UserJobs == null)
		{
			job.UserJobs = new HashSet<UserJobs>();
		}
		job.UserJobs.Add(new UserJobs
		{
			UserEmail = userEmail,
			JobId = jobId,
		});
		_unitOfWork.GetRepository<Job, int>().Update(job);
		try
		{
			await _unitOfWork.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Log.Error(e, e.Message);
			throw new Exception("Error occurred while applying for job. Please try again later.");
		}
		Log.Information($"User {userEmail} applied for job {jobId} successfully.");
		return true;
	}

	public async Task<bool> RemoveJobApplication(int jobId, string? userEmail)
	{
		if (string.IsNullOrEmpty(userEmail))
		{
			Log.Warning("User email is null or empty.");
			throw new UnauthorizedAccessException("User is not logged in");
		}
		if (jobId <= 0)
		{
			Log.Warning($"Invalid job ID: {jobId}");
			throw new ArgumentException("Invalid job ID");
		}
		var jobRepo = _unitOfWork.GetRepository<Job, int>();

		var job = await jobRepo.GetByIdAsync(new JobSpecification(jobId, userEmail));
		if (job is null)
		{
			Log.Warning($"Job with ID {jobId} not found.");
			throw new JobNotFoundException("Job not found. Please Try again later.");
		}
		if (job.UserJobs == null || job.UserJobs.Count == 0)
		{
			Log.Warning($"No applications found for job with ID {jobId}.");
			return true;
		}
		var userJob = job.UserJobs.FirstOrDefault(uj => uj.UserEmail == userEmail);
		if (userJob is null)
		{
			Log.Warning($"No application found for user {userEmail} on job {jobId}.");
			return false;
		}
		job.UserJobs.Remove(userJob);
		jobRepo.Update(job);
		try
		{
			await _unitOfWork.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Log.Error(e, "Error occurred while removing job application.");
			throw new Exception("Error occurred while removing job application. Please try again later.");
		}
		return true;
	}
}