using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TrackPrerequisites
	{
		[Key] public int TrackId { get; }
		public Track Track { get; set; } = default!;

		[MaxLength(250, ErrorMessage = "Maximum length is {250}")]
		public string PrerequisiteName { get; set; } = default!;

		[MaxLength(1000, ErrorMessage = "Maximum length is {1000}")]
		public string PrerequisiteDescription { get; set; } = default!;
	}
}