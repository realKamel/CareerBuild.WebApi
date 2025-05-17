using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppData.Configurations
{
	public class PhaseConfiguration : IEntityTypeConfiguration<Phase>
	{
		public void Configure(EntityTypeBuilder<Phase> builder)
		{
			builder.HasOne(t => t.Exam)
				.WithOne(t => t.Phase)
				.HasForeignKey<Phase>(e => e.ExamId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.Courses)
				.WithOne(x => x.Phase)
				.HasForeignKey(x => x.PhaseId);


		}
	}
}
