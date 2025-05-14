using AbstractServices;
using AutoMapper;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class ServiceManager(
		UserManager<AppUser> _userManager,
		IMapper _mapper,
		IUnitOfWork _unitOfWork) : IServiceManager
	{

		#region Lazy Fields
		private readonly Lazy<IAuthenticationServices> authenticationServices =
		new Lazy<IAuthenticationServices>(() =>
			new AuthenticationServices(_userManager, _mapper, _unitOfWork));
		#endregion


		#region Properties
		public IAuthenticationServices AuthenticationServices => authenticationServices.Value;
		#endregion
	}
}
