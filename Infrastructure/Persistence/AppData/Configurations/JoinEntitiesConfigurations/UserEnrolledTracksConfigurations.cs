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
	internal class UserEnrolledTracksConfigurations : IEntityTypeConfiguration<UserEnrolledTracks>
	{
		public void Configure(EntityTypeBuilder<UserEnrolledTracks> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasOne(b => b.Track)
				.WithMany(b => b.UserEnrolledTracks)
				.HasForeignKey(b => b.TrackId);
		}
	}
}
