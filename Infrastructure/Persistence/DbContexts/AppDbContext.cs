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
		public DbSet<Course> Courses { get; set; }
		public DbSet<Exam> Exams { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<UserSkills> UserSkills { get; set; }
		public DbSet<UserJobs> UserJobs { get; set; }
		public DbSet<UserTracks> UserTracks { get; set; }
		public DbSet<UserExam> UserExams { get; set; }
		#endregion


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//to Apply Configurations From Assembly
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine); // Logs SQL queries to the console
			base.OnConfiguring(optionsBuilder);
		}
	}
}
