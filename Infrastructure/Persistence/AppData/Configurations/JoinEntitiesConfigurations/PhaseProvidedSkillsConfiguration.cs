using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppData.Configurations.JoinEntitiesConfigurations
{
	public class PhaseProvidedSkillsConfiguration : IEntityTypeConfiguration<PhaseProvidedSkills>
	{
		public void Configure(EntityTypeBuilder<PhaseProvidedSkills> builder)
		{
			builder.HasKey(x => new { x.PhaseId, x.SkillId });
			builder.ToTable("PhaseProvidedSkills");

			builder.HasOne(x => x.Phase)
				.WithMany(x => x.PhaseProvidedSkills)
				.HasForeignKey(x => x.PhaseId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.Skill)
				.WithMany(x => x.PhaseProvidedSkills)
				.HasForeignKey(x => x.SkillId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}

}
