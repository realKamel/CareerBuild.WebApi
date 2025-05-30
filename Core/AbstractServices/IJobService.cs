using Shared.Dtos.JobModule;

namespace AbstractServices;

public interface IJobService
{
	Task<IEnumerable<JobDto>> GetAllJobs(string? searchWord);
	Task<JobDto> GetJobById(int id);
	Task<JobDto> CreatedJob(CreatedJobDto createdJobDto, string? companyEmail);
}