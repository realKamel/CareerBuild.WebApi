using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Serilog;
using Services.Specifications;
using Shared.Dtos.JobModule;

namespace Services;

public class JobService(IUnitOfWork _unitOfWork, IMapper _mapper) : IJobService
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
		var result = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(new JobSpecification(id));

		if (result == null)
		{
			throw new JobNotFoundException($"Job with id = {id} is not Found");
		}

		return _mapper.Map<Job, JobDto>(result);
	}

	public async Task<JobDto> CreatedJob(CreatedJobDto createdJobDto, string? companyEmail)
	{
		var mappedJob = _mapper.Map<CreatedJobDto, Job>(createdJobDto);

		if (mappedJob is null || companyEmail is null)
		{
			throw new Exception("Error in Job Post Creating");
		}

		mappedJob.CompanyEmail = companyEmail;

		try
		{
			await _unitOfWork.GetRepository<Job, int>().AddAsync(mappedJob);
			await _unitOfWork.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Log.Error(e.Message, "Error Happen When Posting Job");
			throw;
		}

		var result = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(mappedJob.Id);

		if (result is null)
		{
			throw new JobNotFoundException($"No Job is Found With Id ={mappedJob.Id}");
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
		var job = await _unitOfWork.GetRepository<Job, int>().GetByIdAsync(id);
		if (job is not null)
		{
			_unitOfWork.GetRepository<Job, int>().Remove(job);
			return true;
		}
		return false;
	}

	public async Task<IEnumerable<JobDto>> GetCompanyPostedJobs(string? searchWord, string? email)
	{
		var result = await _unitOfWork.GetRepository<Job, int>().GetAllAsync(new JobSpecification(searchWord, email));
		if (result is null)
		{
			throw new JobNotFoundException("There is no Posted Jobs");
		}
		var mappedJobs = _mapper.Map<IEnumerable<Job>, IEnumerable<JobDto>>(result);
		if (mappedJobs is null)
		{
			throw new Exception("Internal Error");
		}
		return mappedJobs;
	}
}