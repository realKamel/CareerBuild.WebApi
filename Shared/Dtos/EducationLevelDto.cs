using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
	public enum EducationLevelDto
	{
		SecondaryEducation = 1,
		// Typically completed around age 18 (e.g., high school diploma, vocational training completion)
		BachelorsDegree,
		// Typically a 3-4 year university degree
		MastersDegree,
		// Postgraduate degree after a Bachelor's, often 1-2 years
		DoctoralDegree,
		// The highest academic degree (e.g., Ph.D., Ed.D.)
		Other
	}
}
