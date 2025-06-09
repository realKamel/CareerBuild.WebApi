using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Common;
using Shared.Dtos.SkillModule;

namespace Shared.Dtos.JobModule;

public class PostedJobApplication
{
	public int Id { get; set; }

	[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
	public required string Name { get; set; }

	[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
	public string? Description { get; set; } // required

	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset? UpdatedAt { get; set; }
	public required AddressDto Location { get; set; }
	public EmploymentTypeDto EmploymentType { get; set; }
	public string? CompanyName { get; set; }
	public string? CompanyLogoUrl { get; set; } // optional

	#region Relations

	public ICollection<SkillDto>? Skills { get; set; }

	// public ICollection<UserJobsDto>? UserJobs { get; set; } = new HashSet<UserJobs>();
	public required string ApplicationStatus { get; set; }

	#endregion

}
