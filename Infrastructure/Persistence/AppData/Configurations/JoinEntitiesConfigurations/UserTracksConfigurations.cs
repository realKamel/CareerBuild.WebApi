using Domain.Entities;
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
	internal class UserTracksConfigurations : IEntityTypeConfiguration<UserTracks>
	{
		public void Configure(EntityTypeBuilder<UserTracks> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasOne(b => b.Track)
				.WithMany(b => b.UserTracks)
				.HasForeignKey(b => b.TrackId);

			builder.HasIndex(u => new { u.UserEmail, u.TrackId })
				.IsUnique();
		}
	}
}
