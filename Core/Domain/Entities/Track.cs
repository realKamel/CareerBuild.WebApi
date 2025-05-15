using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Track
	{
		[Key]
		public int TrackId { get; set; }
		public string Name { get; set; } = null!; // required
		public string Description { get; set; } = null!; // required
		public TimeOnly EstimatedDuration { get; set; }
		public DifficultyLevel DifficultyLevel { get; set; }

		//Nav props
	}
}
