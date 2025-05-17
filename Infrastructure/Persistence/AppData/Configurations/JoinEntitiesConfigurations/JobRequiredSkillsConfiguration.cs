using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppData.Configurations.JoinEntitiesConfigurations
{
	public class JobRequiredSkillsConfiguration : IEntityTypeConfiguration<JobRequiredSkills>
	{
		public void Configure(EntityTypeBuilder<JobRequiredSkills> builder)
		{
			builder.HasKey(jrs => new { jrs.JobId, jrs.SkillId });

			builder.Property(jrs => jrs.RequiredProficiency)
			 .HasConversion<string>();

			builder.HasOne(jrs => jrs.Job)
				.WithMany(j => j.JobRequiredSkills)
				.HasForeignKey(jrs => jrs.JobId);

			builder.HasOne(jrs => jrs.Skill)
				.WithMany(s => s.JobRequiredSkills)
				.HasForeignKey(jrs => jrs.SkillId);
		}
	}
}
