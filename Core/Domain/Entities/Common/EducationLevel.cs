using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
	public enum EducationLevel
	{
		SECONDARY_EDUCATION = 1,
		// Typically completed around age 18 (e.g., high school diploma, vocational training completion)
		BACHELORS_DEGREE,
		// Typically a 3-4 year university degree
		MASTERS_DEGREE,
		// Postgraduate degree after a Bachelor's, often 1-2 years
		DOCTORAL_DEGREE, 
		// The highest academic degree (e.g., Ph.D., Ed.D.)
		OTHER_TERTIARY_QUALIFICATION 
		// For other significant tertiary qualifications that don't fit neatly into the above
	}
}
