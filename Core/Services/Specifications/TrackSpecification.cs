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
			AddInclude(x => x.Phases);
		}

		public TrackSpecification(string searchWord)
			: base(p => string.IsNullOrWhiteSpace(searchWord)
			|| p.Name.ToLower().Contains(searchWord.ToLower()))
		{
			AddInclude(x => x.Phases);
			AddInclude("Phases.Courses");
			AddInclude("Phases.Exam");
		}
	}
}