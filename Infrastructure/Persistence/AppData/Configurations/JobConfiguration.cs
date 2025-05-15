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
	public class JobConfigurations : IEntityTypeConfiguration<Job>
	{
		public void Configure(EntityTypeBuilder<Job> builder)
		{
			builder.HasKey(j => j.JobId); //PK

			// the Address is mapped by data notation to be owned class 

			builder.Property(j => j.EmploymentType)
				.HasConversion(em => em.ToString()
				, em => Enum.Parse<EmploymentType>(em));

			builder.Property(j => j.MinSalary)
				.HasColumnType("decimal(10,2)");

			builder.Property(j => j.MaxSalary)
				.HasColumnType("decimal(10,2)");

			builder.ToTable(jt =>
			jt.HasCheckConstraint("ensure_salary_Range_check",
			"[MaxSalary] >= [MinSalary]"));


			builder.ToTable(t =>
			t.HasCheckConstraint("ensure_salary_Range_check", "[Salary] >= 1000"));
		}
	}
}
