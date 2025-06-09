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
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(x => x.Id);// for PK

			//For the conversion of the Enum
			builder.Property(c => c.DifficultyLevel)
				.HasConversion(cd => cd.ToString(),
				cd => Enum.Parse<DifficultyLevel>(cd));
		}
	}
}
