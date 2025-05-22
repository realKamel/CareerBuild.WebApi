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
	internal class UserJobsConfigurations : IEntityTypeConfiguration<UserJobs>
	{
		public void Configure(EntityTypeBuilder<UserJobs> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasOne(b=> b.Job)
				.WithMany(b=> b.UserJobs)
				.HasForeignKey(b=> b.JobId);
		}
	}
}
