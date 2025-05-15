using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
		#endregion


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//to Apply Configurations From Assembly

			modelBuilder
				.ApplyConfigurationsFromAssembly(typeof(PersistenceServiceRegistration).Assembly);
		}
	}
}
