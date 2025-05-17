using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppData.Configurations
{
	public class SkillConfiguration : IEntityTypeConfiguration<Skill>
	{
		public void Configure(EntityTypeBuilder<Skill> builder)
		{
			builder.HasOne(e => e.Exam).WithMany(x => x.Skills)
				.HasForeignKey(e => e.ExamID);

			builder.HasOne(e => e.Course).WithMany(x => x.Skills)
				.HasForeignKey(e => e.CourseID);

			//to make sure skill category is not null in the database
			builder.Property(b => b.Category)
				.HasConversion(
					b => b.ToString(),
					b => string.IsNullOrEmpty(b)
						? SkillCategory.None
						: Enum.Parse<SkillCategory>(b));
		}
	}
}
