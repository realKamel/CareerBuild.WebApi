using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
	public class TrackPrerequisites
	{
		[Key] public int TrackId { get; }
		public Track Track { get; set; } = null!;

		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string PrerequisiteName { get; set; } = default!;

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string PrerequisiteDescription { get; set; } = default!;
	}
}