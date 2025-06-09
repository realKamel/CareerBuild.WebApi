using Domain.Entities;

namespace Services.Specifications;

public class JobSpecification : BaseSpecification<Job, int>
{
	public JobSpecification(string? searchWord, string? companyEmail)
		: base(p =>
			  (string.IsNullOrWhiteSpace(searchWord) || p.Name.ToLower().Contains(searchWord.ToLower()))
			   &&
			  (string.IsNullOrWhiteSpace(companyEmail) || p.CompanyEmail == companyEmail))
	{
		AddInclude(p => p.Skills);
	}

	public JobSpecification(int id, string? userEmail) : base(p => p.Id == id)
	{
		AddInclude(p => p.Skills);
		AddInclude(p => p.UserJobs.Where(u => u.UserEmail == userEmail));
	}

	public JobSpecification(string? userEmail) : base(p => true)
	{
		AddInclude(p => p.Skills);
		AddInclude(p => p.UserJobs.Where(u => u.UserEmail == userEmail));
	}
}