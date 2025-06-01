using System.Linq.Expressions;
using Domain.Entities;

namespace Services.Specifications;

public class JobSpecification : BaseSpecification<Job, int>
{
	public JobSpecification(string? searchWord)
		: base(p => string.IsNullOrWhiteSpace(searchWord) || p.Name.ToLower().Contains(searchWord.ToLower()))
	{
		AddInclude(p => p.Skills);
	}

	public JobSpecification(int id) : base(p => p.Id == id)
	{
		AddInclude(p => p.Skills);
	}
}