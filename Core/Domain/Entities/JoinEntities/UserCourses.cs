using System;

namespace Domain.Entities.JoinEntities;

public class UserCourses : UserBaseEntity
{
	public int CourseId { get; set; }
	public Course Course { get; set; } = null!;
	public DateTimeOffset? FinishedAt { get; set; } = null;
	public string? CertificateUrl { get; set; }
	public bool IsPassed { get; set; } = false;

}
