using Microsoft.Win32;
using Shared.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractServices
{
	public interface IAuthenticationServices
	{
		//Login user
		public Task<LoggedInUser> LoginRegularUserAsync(LoginDto loginDto);

		//Login company
		public Task<LoggedInCompany> LoginCompanyAsync(LoginDto loginDto);

		//register normal User
		public Task<bool> RegisterRegularUserAsync(RegisterUserDto userDto);

		//register company User
		public Task<bool> RegisterCompanyUserAsync(RegisterCompanyDto companyDto);

	}
}
