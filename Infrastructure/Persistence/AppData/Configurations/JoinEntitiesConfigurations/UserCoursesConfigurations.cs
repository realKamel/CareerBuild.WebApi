using System;
using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.AppData.Configurations.JoinEntitiesConfigurations;

public class UserCoursesConfigurations : IEntityTypeConfiguration<UserCourses>
{
	public void Configure(EntityTypeBuilder<UserCourses> builder)
	{
		builder.HasKey(b => b.Id);
		builder.HasIndex(u => new { u.UserEmail, u.CourseId })
			.IsUnique();
	}
}
