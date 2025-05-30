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
	public ICollection<SkillDto>? Skills { get; set; }
}