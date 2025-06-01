using Shared.Dtos.TrackModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.TrackModule
{
	public class UserTracksDto : BaseDto
	{
		public TrackDto? Track { get; set; }
		public DateTimeOffset? FinishedAt { get; set; } = null;
		public bool IsFinished { get; set; } = false;
		public string? EnrollmentStatus { get; set; }
	}
}
