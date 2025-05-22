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
	internal class UserPassedPhasesConfiguration : IEntityTypeConfiguration<UserPassedPhases>
	{
		public void Configure(EntityTypeBuilder<UserPassedPhases> builder)
		{
			builder.HasKey(b => new {b.TrackId , b.PhaseId});

			builder.HasOne(b => b.Track)
				.WithMany(b => b.UserPassedPhases)
				.HasForeignKey(b => b.TrackId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(b => b.Phase)
				.WithMany(b => b.UserPassedPhases)
				.HasForeignKey(b => b.PhaseId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
