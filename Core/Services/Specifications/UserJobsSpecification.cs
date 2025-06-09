using System;
using System.Linq.Expressions;
using Domain.Entities.JoinEntities;

namespace Services.Specifications;

public class UserJobsSpecification : BaseSpecification<UserJobs, Guid>
{
	public UserJobsSpecification() : base(p => true)
	{
		AddInclude("Job.Skills");
	}
}
