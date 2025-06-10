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
		public TrackSpecification(Expression<Func<Track, bool>>? CriteriaExp) : base(CriteriaExp)
		{
			AddInclude(x => x.Courses);
			AddInclude("Courses.Skills");
		}

		public TrackSpecification(string? searchWord)
			: base(p => string.IsNullOrWhiteSpace(searchWord)
			|| p.Name.ToLower().Contains(searchWord.ToLower()))
		{
			// AddInclude(t => t.Courses); // Include Phases
			// AddInclude(t => t.Phases.Select(p => p.Courses)); // Include Courses within Phases
			// AddInclude(t => t.Phases.SelectMany(p => p.Courses.Select(c => c.Skills))); // Include Skills within Courses
			// AddInclude("Phases.Courses");
			// AddInclude("Phases.Courses.Skills");
		}

		public TrackSpecification(int id)
			: base(p => p.Id == id)
		{
			AddInclude(t => t.Courses); // Include Phases
										// AddInclude("Phases.Courses");
			AddInclude("Courses.Skills");
		}
	}
}