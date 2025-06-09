using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Domain.Entities.JoinEntities;

namespace Domain.Entities
{
	public class Track : BaseEntity<int>
	{
		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string Name { get; set; } = null!; // required

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string? Description { get; set; } = null!; // required

		private int durationInHours;
		public int DurationInHours
		{
			get
			{
				if (Courses == null || Courses.Count == 0)
					return 0;
				// Calculate the total duration in hours from the courses
				return Courses.Sum(c => c.DurationInHours);
			}
			set { durationInHours = value; }
		}

		public DifficultyLevel DifficultyLevel { get; set; }

		public string? CoverUrl { get; set; } // optional
		public string? ProviderName { get; set; } // optional
		#region Relations

		public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();

		public ICollection<Exam>? Exams { get; set; } = new HashSet<Exam>();

		[NotMapped]
		private ICollection<Skill>? skills;
		public ICollection<Skill>? Skills
		{
			get
			{
				if (Courses == null || Courses.Count == 0)
					return new HashSet<Skill>();

				// Aggregate skills from all courses
				return Courses.SelectMany(c => c.Skills).Distinct().ToList();
			}
			set
			{
				skills = value;
			}
		}

		public ICollection<TrackPrerequisites>? TrackPrerequisites { get; set; } =
			new HashSet<TrackPrerequisites>();

		public ICollection<UserTracks>? UserTracks = new HashSet<UserTracks>();

		#endregion
	}
}