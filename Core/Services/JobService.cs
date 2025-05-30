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
		var result = await _unitOfWork.GetRepository<Job, int>().GetAllAsync(new JobSpecification(searchWord));

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
}