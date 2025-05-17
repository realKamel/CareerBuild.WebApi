using Domain.Entities;
using Domain.Entities.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Persistence.AppData.Configurations.JoinEntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbContexts
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		// Define DbSets here
		// public DbSet<YourEntity> YourEntities { get; set; }

		#region DbSets
		public DbSet<Course> Course { get; set; }
		public DbSet<Exam> Exams { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Phase> Phases { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<UserAcquiredSkills> UserAcquiredSkills { get; set; }
		public DbSet<UserAppliedJobs> UserAppliedJobs { get; set; }
		public DbSet<UserEnrolledTracks> UserEnrolledTracks { get; set; }
		public DbSet<UserEnteredExams> UserEnteredExams { get; set; }
		public DbSet<UserPassedPhases> UserPassedPhases { get; set; }

		#endregion


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//to Apply Configurations From Assembly
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

			//modelBuilder.ApplyConfiguration(new JobRequiredSkillsConfiguration());
		}
	}
}
