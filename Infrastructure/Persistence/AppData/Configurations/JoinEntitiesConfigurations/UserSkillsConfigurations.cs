﻿using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppData.Configurations.JoinEntitiesConfigurations
{
	public class UserSkillsConfigurations : IEntityTypeConfiguration<UserSkills>
	{
		public void Configure(EntityTypeBuilder<UserSkills> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasOne(b => b.Skill)
				.WithMany(b => b.UserSkills)
				.HasForeignKey(b => b.SkillId);

			builder.HasIndex(u => new { u.UserEmail, u.SkillId })
				.IsUnique();
		}
	}
}
