using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class TrackPrerequisites
	{
		public int TrackId { get; set; }
		public Track Track { get; set; } = default!;
		public string PrerequisiteName { get; set; } = default!;
		public string PrerequisiteDescription { get; set; } = default!;
	}
}
