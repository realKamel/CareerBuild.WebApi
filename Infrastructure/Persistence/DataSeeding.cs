using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Entities.JoinEntities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence
{
	public class DataSeeding(
		IdentityContext _identityDb,
		UserManager<AppUser> _userManager,
		RoleManager<IdentityRole> _roleManager,
		AppDbContext _appDb
	) : IDataSeeding
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
					var tracks = new List<Track>
					{
						new Track()
						{
							Name = "Front End Development",
							Description =
								"A comprehensive learning path designed to equip learners with the essential skills for building modern, interactive web interfaces using client-side technologies.",
							DifficultyLevel = DifficultyLevel.Beginner,
							CreatedBy = "Admin",
							CoverUrl = "https://banner2.cleanpng.com/20180605/yjb/aa9yal4pp.webp",
							ProviderName = "CareerBuild",

							Courses = new List<Course>()
							{
								new Course()
								{
									CourseOrderInTrack = 1,
									Name = "HTML Basics",
									Description =
										"An introductory course covering the fundamentals of HTML including tags, elements, attributes, and document structure.",
									DurationInHours = 10,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									CourseUrl = "https://www.w3schools.com/html/",
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "HTML",
											Description =
												"HyperText Markup Language used to define the structure and semantics of web content.",
											Category = SkillCategory.ProgrammingLanguage,
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 2,
									Name = "CSS Fundamentals",
									Description =
										"Learn how to style your websites using CSS, including selectors, box model, layout, and responsive design basics.",
									DurationInHours = 15,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									CourseUrl = "https://www.w3schools.com/css/",
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "CSS",
											Description =
												"Cascading Style Sheets language used to control the visual presentation and layout of HTML documents.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 3,
									Name = "JavaScript Basics",
									Description =
										"An entry-level course teaching the fundamentals of JavaScript including variables, functions, loops, and basic DOM interaction.",
									DurationInHours = 20,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "JavaScript",
											Description =
												"A versatile scripting language that enables dynamic updates, control over browser behavior, and asynchronous communication.",
											Category = SkillCategory.ProgrammingLanguage,
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 4,
									Name = "Intro to DOM Manipulation",
									Description =
										"Learn how to access and manipulate HTML elements programmatically using JavaScript to build interactive web applications.",
									DurationInHours = 10,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "DOM Manipulation",
											Description =
												"Techniques used to access, modify, and interact with the structure and content of a webpage in real-time.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 5,
									Name = "Responsive Design Essentials",
									Description =
										"Learn the essentials of creating flexible layouts using media queries, flexbox, and grid to build mobile-friendly websites.",
									DurationInHours = 15,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "Responsive Web Design",
											Description =
												"Design approach that ensures web pages render well on all devices and screen resolutions.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 6,
									Name = "Getting Started with Git",
									Description =
										"Introduction to version control using Git, including repositories, commits, branches, and cloning.",
									DurationInHours = 10,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "Git : Version Control",
											Description =
												"A system for tracking changes in source code during software development, widely used for collaborative coding.",
										},
									},
								},
							},
						},
						new Track()
						{
							Name = "Back End Development",
							Description =
								"A structured learning journey focusing on server-side development, APIs, databases, and application logic using modern backend technologies.",
							DifficultyLevel = DifficultyLevel.Intermediate,
							CoverUrl =
								"https://cdn-media-0.freecodecamp.org/size/w2000/2024/03/backendroadmap.png",
							CreatedBy = "Admin",
							Courses = new List<Course>()
							{
								new Course()
								{
									CourseOrderInTrack = 1,
									Name = "Node.js Basics",
									Description =
										"A beginner-friendly course introducing the basics of server-side development using Node.js, including modules, file systems, and HTTP servers.",
									DurationInHours = 20,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "Node.js",
											Description =
												"A powerful runtime environment that executes JavaScript code outside of a web browser, ideal for scalable network applications.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 2,
									Name = "Express.js Fundamentals",
									Description =
										"Learn how to build RESTful APIs and server-side applications using Express.js, one of the most popular frameworks for Node.js.",
									DurationInHours = 20,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "Express.js",
											Description =
												"A fast and minimalist web framework for Node.js used to build web applications and RESTful APIs efficiently.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 3,
									Name = "SQL for Backend Developers",
									Description =
										"Learn SQL fundamentals required for backend development including queries, joins, transactions, and normalization.",
									DurationInHours = 25,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "SQL / Relational Databases",
											Description =
												"Structured Query Language used to manage and query data in relational database systems like PostgreSQL or MySQL.",
										},
									},
								},
								new Course()
								{
									CourseOrderInTrack = 4,
									Name = "MongoDB Introduction",
									Description =
										"Get started with MongoDB, a leading NoSQL database, and learn how to store and query unstructured data effectively.",
									DurationInHours = 20,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "MongoDB / NoSQL",
											Description =
												"A document-based NoSQL database that provides high scalability and flexibility for storing varied data types.",
										},
									},
								},
								new Course()
								{
									Name = "Building RESTful APIs with Express",
									Description =
										"Learn how to design and implement RESTful APIs using Express.js, including routes, middleware, and request handling.",
									DurationInHours = 20,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Beginner,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "RESTful API",
											Description =
												"Architectural style for designing networked applications based on HTTP methods and stateless interactions.",
										},
									},
								},
								new Course()
								{
									Name = "Authentication with JWT",
									Description =
										"Implement user authentication and session management using JSON Web Tokens (JWT) in Node.js-based backend applications.",
									DurationInHours = 15,
									CreatedBy = "Admin",
									DifficultyLevel = DifficultyLevel.Intermediate,
									Skills = new List<Skill>()
									{
										new Skill()
										{
											Name = "JWT / OAuth",
											Description =
												"Security protocols used to authenticate and authorize users and systems in distributed environments.",
										},
									},
								},
							},
						},
					};

					//await _unitOfWork.GetRepository<Track, int>().AddAsync(track);
					//await _unitOfWork.SaveChangesAsync();
					await _appDb.Tracks.AddRangeAsync(tracks);
				}

				if (!_appDb.Jobs.Any())
				{
					Job jobs = new()
					{
						Name = "Software Engineer",
						Description =
							"Responsible for developing and maintaining software applications, collaborating with cross-functional teams to deliver high-quality solutions.",
						CreatedBy = "Admin",
						CompanyEmail = "abc@gmail.com",
						Skills =
						[
							new Skill()
							{
								Name = "C#",
								Description =
									"A modern, object-oriented programming language developed by Microsoft, widely used for building Windows applications and web services.",
								Category = SkillCategory.ProgrammingLanguage,
							},
							new Skill()
							{
								Name = "ASP.NET Core",
								Description =
									"A cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications.",
								Category = SkillCategory.Framework,
							},
							new Skill()
							{
								Name = "SQL Server",
								Description =
									"A relational database management system developed by Microsoft, used to store and retrieve data for software applications.",
								Category = SkillCategory.Database,
							},
						],
						EmploymentType = EmploymentType.FullTime,
						Location = new Address()
						{
							Street = "456 Tech Lane",
							City = "Cairo",
							Country = "Egypt",
						},
						MinSalary = 10000,
						MaxSalary = 12000,
						ExpiresAt = DateTimeOffset.Now.AddDays(30),
					};
					await _appDb.Jobs.AddAsync(jobs);
				}

				await _appDb.SaveChangesAsync();
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
						Address = new Address()
						{
							Street = "123",
							City = "Giza",
							Country = "Egypt",
						},
						UserName = "abdelrahman",
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
