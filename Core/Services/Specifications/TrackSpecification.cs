using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Specifications
{
	public class TrackSpecification : BaseSpecification<Track, int>
	{
		public TrackSpecification(string? searchWord)
			: base(p => string.IsNullOrWhiteSpace(searchWord)
			|| p.Name.ToLower().Contains(searchWord.ToLower()))
		{

		}

		public TrackSpecification(int id)
			: base(p => p.Id == id)
		{
			// when hitting the track with id all related data should be loaded
			AddInclude(t => t.Courses);
			AddInclude("Courses.Skills");
		}
	}
}