using Microsoft.Win32;
using Shared.Dtos.Identity.Login;
using Shared.Dtos.Identity.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractServices
{
	public interface IAuthenticationServices
	{
		//Login user
		public Task<LoggedInUserDto> LoginRegularUserAsync(LoginDto loginDto);

		//Login company
		public Task<LoggedInCompanyDto> LoginCompanyAsync(LoginDto loginDto);


		//public Task<TEntity> LoginAsync<TBase, TEntity>(LoginDto loginDto,
		//	Expression<Func<TBase, object>> expression) where TBase : class ;

		//register normal User
		public Task<bool> RegisterRegularUserAsync(RegisterUserDto userDto);

		//register company User
		public Task<bool> RegisterCompanyUserAsync(RegisterCompanyDto companyDto);

	}
}
