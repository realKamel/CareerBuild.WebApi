using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
	public sealed class TrackNotFoundException : NotFoundException
	{
		public TrackNotFoundException(string message) : base(message)
		{
		}

		public TrackNotFoundException(int id) : base($"Track with the given {id} is not Found")
		{
		}
	}
}
