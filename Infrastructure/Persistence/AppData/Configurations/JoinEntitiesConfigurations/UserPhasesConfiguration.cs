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
	internal class UserPhasesConfiguration : IEntityTypeConfiguration<UserPhases>
	{
		public void Configure(EntityTypeBuilder<UserPhases> builder)
		{
			builder.HasKey(b => new {b.TrackId , b.PhaseId});

			builder.HasOne(b => b.Track)
				.WithMany(b => b.UserPhases)
				.HasForeignKey(b => b.TrackId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(b => b.Phase)
				.WithMany(b => b.UserPhases)
				.HasForeignKey(b => b.PhaseId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
