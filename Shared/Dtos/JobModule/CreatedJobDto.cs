using Shared.Dtos.Common;
using Shared.Dtos.SkillModule;

namespace Shared.Dtos.JobModule;

public class CreatedJobDto
{
	public required string Name { get; set; }
	public required string Description { get; set; }

	public AddressDto Location { get; set; } = null!;

	// public DateTime? ExpiresAt { get; set; } // this is optional
	public EmploymentTypeDto EmploymentType { get; set; }
	public decimal MinSalary { get; set; }
	public decimal MaxSalary { get; set; }
	public ICollection<CreatedSkillDto>? Skills { get; set; }
}
