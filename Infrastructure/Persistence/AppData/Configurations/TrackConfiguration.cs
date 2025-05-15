using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;

namespace Persistence.AppData.Configurations
{
	public class TrackConfiguration : IEntityTypeConfiguration<Track>
	{
		public void Configure(EntityTypeBuilder<Track> builder)
		{
			builder.HasKey(d => d.TrackId);
			builder.Property(d => d.DifficultyLevel)
				.HasConversion(dl => dl.ToString(),
				(dl => Enum.Parse<DifficultyLevel>(dl)));
		}
	}
}
