using Shared.Dtos.SkillModule;

namespace Shared.Dtos.JobModule;

public class JobDto : BaseDto
{
	public AddressDto Location { get; set; } = null!;
	public DateTimeOffset? ExpiresAt { get; set; }
	public required string EmploymentType { get; set; }
	public decimal MinSalary { get; set; }
	public decimal MaxSalary { get; set; }
	public required string CompanyEmail { get; set; }
	public required string CompanyName { get; set; } // Optional, can be null if not provided
	public string? CompanyLogoUrl { get; set; } // optional
	public string WebsiteUrl { get; set; } = default!;
	public ICollection<SkillDto>? Skills { get; set; }
}