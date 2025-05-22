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
	public class UserAcquiredSkillsConfigurations : IEntityTypeConfiguration<UserAcquiredSkills>
	{
		public void Configure(EntityTypeBuilder<UserAcquiredSkills> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasOne(b => b.Skill)
				.WithMany(b => b.UserAcquiredSkills)
				.HasForeignKey(b => b.SkillId);
		}
	}
}
