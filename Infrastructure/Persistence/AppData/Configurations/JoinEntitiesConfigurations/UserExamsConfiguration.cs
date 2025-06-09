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
	public class UserExamsConfiguration : IEntityTypeConfiguration<UserExam>
	{
		public void Configure(EntityTypeBuilder<UserExam> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasIndex(u => new { u.UserEmail, u.ExamId })
				.IsUnique(true);
		}
	}
}
