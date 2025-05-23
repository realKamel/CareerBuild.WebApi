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
		AppDbContext _appDb,
		IUnitOfWork _unitOfWork) : IDataSeeding
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
							EstimatedDurationInHours = 200,
							DifficultyLevel = DifficultyLevel.Easy,
							CreatedBy = "Admin",
							Phases = new List<Phase>()
							{
								new Phase()
								{
									Name = "Phase 1: Foundational Web Technologies (The Building Blocks)",
									Description =
										"This phase introduces the fundamental languages of the web—HTML for structure and CSS for styling—providing a solid base for further frontend development.",
									EstimatedDurationInHours = 35,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"HTML is essential for structuring content on the web, making it the foundation of any frontend development.",
											Skill = new Skill()
											{
												Name = "HTML",
												Description =
													"HyperText Markup Language used to define the structure and semantics of web content."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"CSS is critical for styling and layout, enabling developers to create visually appealing user interfaces.",
											Skill = new Skill()
											{
												Name = "CSS",
												Description =
													"Cascading Style Sheets language used to control the visual presentation and layout of HTML documents."
											}
										},
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "HTML Basics",
											Description =
												"An introductory course covering the fundamentals of HTML including tags, elements, attributes, and document structure.",
											DurationInHours = 10,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "CSS Fundamentals",
											Description =
												"Learn how to style your websites using CSS, including selectors, box model, layout, and responsive design basics.",
											DurationInHours = 15,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
								new Phase()
								{
									Name = "Phase 2: JavaScript and the DOM (The Brain)",
									Description =
										"This phase dives into JavaScript, introducing core programming concepts and how to manipulate web pages dynamically using the Document Object Model (DOM).",
									EstimatedDurationInHours = 65,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"JavaScript powers interactivity and dynamic behavior on websites, making it indispensable for modern web development.",
											Skill = new Skill()
											{
												Name = "JavaScript",
												Description =
													"A versatile scripting language that enables dynamic updates, control over browser behavior, and asynchronous communication."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"Understanding DOM manipulation is crucial for dynamically updating page content and responding to user actions.",
											Skill = new Skill()
											{
												Name = "DOM Manipulation",
												Description =
													"Techniques used to access, modify, and interact with the structure and content of a webpage in real-time."
											}
										},
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "JavaScript Basics",
											Description =
												"An entry-level course teaching the fundamentals of JavaScript including variables, functions, loops, and basic DOM interaction.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "Intro to DOM Manipulation",
											Description =
												"Learn how to access and manipulate HTML elements programmatically using JavaScript to build interactive web applications.",
											DurationInHours = 10,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
								new Phase()
								{
									Name = "Phase 3: Responsive Design & Modern Tools",
									Description =
										"This phase covers responsive web design principles and modern tooling such as version control, package managers, and developer workflows.",
									EstimatedDurationInHours = 40,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"Responsive design ensures websites work seamlessly across devices and screen sizes, which is essential in modern front-end development.",
											Skill = new Skill()
											{
												Name = "Responsive Web Design",
												Description =
													"Design approach that ensures web pages render well on all devices and screen resolutions."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"Version control systems like Git are essential for collaboration and managing source code changes effectively.",
											Skill = new Skill()
											{
												Name = "Git : Version Control",
												Description =
													"A system for tracking changes in source code during software development, widely used for collaborative coding."
											}
										}
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "Responsive Design Essentials",
											Description =
												"Learn the essentials of creating flexible layouts using media queries, flexbox, and grid to build mobile-friendly websites.",
											DurationInHours = 15,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "Getting Started with Git",
											Description =
												"Introduction to version control using Git, including repositories, commits, branches, and cloning.",
											DurationInHours = 10,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								}
							}
						},
						new Track()
						{
							Name = "Back End Development",
							Description =
								"A structured learning journey focusing on server-side development, APIs, databases, and application logic using modern backend technologies.",
							EstimatedDurationInHours = 350,
							DifficultyLevel = DifficultyLevel.Medium,
							CreatedBy = "Admin",
							Phases = new List<Phase>()
							{
								new Phase()
								{
									Name = "Phase 1: Server-Side Programming (The Engine)",
									Description =
										"This phase explores the essentials of backend development using Node.js and Express.js, laying the groundwork for building scalable and efficient web servers and APIs.",
									EstimatedDurationInHours = 60,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"Node.js allows developers to use JavaScript on the server, providing a unified language across the full stack.",
											Skill = new Skill()
											{
												Name = "Node.js",
												Description =
													"A powerful runtime environment that executes JavaScript code outside of a web browser, ideal for scalable network applications."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"Express.js is a minimal and flexible framework that simplifies building robust APIs and backend services using Node.js.",
											Skill = new Skill()
											{
												Name = "Express.js",
												Description =
													"A fast and minimalist web framework for Node.js used to build web applications and RESTful APIs efficiently."
											}
										},
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "Node.js Basics",
											Description =
												"A beginner-friendly course introducing the basics of server-side development using Node.js, including modules, file systems, and HTTP servers.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "Express.js Fundamentals",
											Description =
												"Learn how to build RESTful APIs and server-side applications using Express.js, one of the most popular frameworks for Node.js.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
								new Phase()
								{
									Name = "Phase 2: Databases and ORM",
									Description =
										"This phase focuses on integrating databases into backend applications using relational and non-relational models, along with Object Relational Mappers (ORMs) for easier data management.",
									EstimatedDurationInHours = 70,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"Relational databases are foundational for managing structured data in enterprise and transactional systems.",
											Skill = new Skill()
											{
												Name = "SQL / Relational Databases",
												Description =
													"Structured Query Language used to manage and query data in relational database systems like PostgreSQL or MySQL."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"NoSQL databases offer flexibility and scalability for handling unstructured or semi-structured data commonly used in modern web applications.",
											Skill = new Skill()
											{
												Name = "MongoDB / NoSQL",
												Description =
													"A document-based NoSQL database that provides high scalability and flexibility for storing varied data types."
											}
										}
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "SQL for Backend Developers",
											Description =
												"Learn SQL fundamentals required for backend development including queries, joins, transactions, and normalization.",
											DurationInHours = 25,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "MongoDB Introduction",
											Description =
												"Get started with MongoDB, a leading NoSQL database, and learn how to store and query unstructured data effectively.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										}
									}
								},
								new Phase()
								{
									Name = "Phase 3: API Design and Authentication",
									Description =
										"This phase teaches how to design secure and scalable RESTful APIs and implement authentication and authorization strategies for protecting backend services.",
									EstimatedDurationInHours = 60,
									PhaseSkills = new List<PhaseSkills>()
									{
										new PhaseSkills()
										{
											RecommendationReason =
												"RESTful APIs are the standard way to enable communication between frontend and backend components in modern applications.",
											Skill = new Skill()
											{
												Name = "RESTful API",
												Description =
													"Architectural style for designing networked applications based on HTTP methods and stateless interactions."
											}
										},
										new PhaseSkills()
										{
											RecommendationReason =
												"Authentication and authorization ensure that only authorized users can access protected resources in an application.",
											Skill = new Skill()
											{
												Name = "JWT / OAuth",
												Description =
													"Security protocols used to authenticate and authorize users and systems in distributed environments."
											}
										}
									},
									Courses = new List<Course>
									{
										new Course()
										{
											Name = "Building RESTful APIs with Express",
											Description =
												"Learn how to design and implement RESTful APIs using Express.js, including routes, middleware, and request handling.",
											DurationInHours = 20,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Easy,
										},
										new Course()
										{
											Name = "Authentication with JWT",
											Description =
												"Implement user authentication and session management using JSON Web Tokens (JWT) in Node.js-based backend applications.",
											DurationInHours = 15,
											CreatedBy = "Admin",
											DifficultyLevel = DifficultyLevel.Medium,
										}
									}
								}
							}
						}
					};

					//await _unitOfWork.GetRepository<Track, int>().AddAsync(track);
					//await _unitOfWork.SaveChangesAsync();
					await _appDb.Tracks.AddRangeAsync(tracks);
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