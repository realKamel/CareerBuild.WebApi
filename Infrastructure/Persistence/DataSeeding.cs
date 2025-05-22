using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Entities.JoinEntities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class DataSeeding(IdentityContext _identityDb,
		UserManager<AppUser> _userManager,
		RoleManager<IdentityRole> _roleManager, AppDbContext _appDb, IUnitOfWork _unitOfWork) : IDataSeeding
	{
		public async Task AppDataSeeding()
		{
			try
			{
				var pendingMigration = await _appDb.Database.GetPendingMigrationsAsync();
				if (pendingMigration.Any())
				{
					await _identityDb.Database.MigrateAsync();
				}
				if (!_appDb.Tracks.Any())
				{
					var track = new Track()
					{
						Name = "Front End Development",
						Description = "Web Development Track",
						EstimatedDurationInHours = 300,
						DifficultyLevel = DifficultyLevel.Easy,
						CreatedBy = "Admin",
						Phases = new List<Phase>()
							{
								new Phase()
								{
									Name = "Phase 1: Foundational Web Technologies (The Building Blocks)",
									Description = "This phase focuses on the absolute core technologies that every frontend developer must master.",
									EstimatedDurationInHours = 30,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason = "Good",
											Skill = new Skill()
											{
												Name = "HTML",
												Description = "The standard markup language for creating web pages.",
											}
										},
										new PhaseSkills()
										{
											RecommendationReason = "Good",
											Skill = new Skill()
											{
												Name = "CSS",
												Description = "A style sheet language used for describing the presentation of a document written in HTML.",
											}
										},
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "HTML Basics",
											Description = "Learn the basics of HTML, the standard markup language for creating web pages.",
											DurationInHours = 10,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
								new Phase()
								{
									Name = "Phase 2: JavaScript and the DOM (The Brain)",
									Description = "This phase focuses on JavaScript, the programming language of the web, and the Document Object Model (DOM).",
									EstimatedDurationInHours = 50,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason = "Good",
											Skill = new Skill()
											{
												Name = "JavaScript",
												Description = "A programming language that conforms to the ECMAScript specification.",
											}
										},
										new PhaseSkills()
										{
											RecommendationReason = "Good",
											Skill = new Skill()
											{
												Name = "DOM Manipulation",
												Description = "The process of programmatically changing the document structure, style, and content.",
											}
										},
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "JavaScript Basics",
											Description = "Learn the basics of JavaScript, the programming language of the web.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
							}
					};

					await _unitOfWork.GetRepository<Track, int>().AddAsync(track);
					await _unitOfWork.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task IdentityDataSeedingAsync()
		{
			try
			{
				var pendingMigration = await _identityDb.Database.GetPendingMigrationsAsync();

				if (pendingMigration.Any())
				{
					await _identityDb.Database.MigrateAsync();
				}
				if (!_roleManager.Roles.Any())
				{
					await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
				}
				if (!_userManager.Users.Any())
				{
					var user = new AppUser()
					{
						Email = "Abdelrahman@gmail.com",
						PhoneNumber = "01014202765",
						Address = new Address() { Street = "123", City = "Giza", Country = "Egypt" },
						UserName = "abdelrahman"
					};

					await _userManager.CreateAsync(user, "P@assw0rd");

					await _userManager.AddToRoleAsync(user, "SuperAdmin");
				}
				await _identityDb.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
