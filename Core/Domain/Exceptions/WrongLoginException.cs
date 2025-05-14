using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
	public sealed class WrongLoginException(string message = "Wrong Email Or Password")
		: Exception(message)
	{
	}
}
