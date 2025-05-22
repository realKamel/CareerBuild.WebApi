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
	public class UserEnteredExamsConfiguration : IEntityTypeConfiguration<UserEnteredExam>
	{
		public void Configure(EntityTypeBuilder<UserEnteredExam> builder)
		{
			builder.HasKey(b => b.Id);

			builder.HasIndex(b => b.UserEmail)
				.IsUnique(true);
		}
	}
}
