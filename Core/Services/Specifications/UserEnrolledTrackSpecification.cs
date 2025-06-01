using Domain.Entities;
using Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
	internal class UserEnrolledTrackSpecification : BaseSpecification<UserTracks, Guid>
	{
		public UserEnrolledTrackSpecification(string userEmail)
		: base(p => p.UserEmail.ToLower() == userEmail.ToLower())
		{
			AddInclude(x => x.Track);
		}

		public UserEnrolledTrackSpecification(Expression<Func<UserTracks, bool>>? CriteriaExp) : base(CriteriaExp)
		{
			AddInclude(x => x.Track);
		}
	}
}
