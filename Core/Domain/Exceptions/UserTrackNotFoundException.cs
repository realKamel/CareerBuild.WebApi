using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
	public sealed class UserTrackNotFoundException() : NotFoundException("User is Not enrolled at any track")
	{
	}
}
