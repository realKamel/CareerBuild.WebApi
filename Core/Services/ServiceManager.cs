using AbstractServices;
using AutoMapper;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
		IConfiguration Configuration,
		IUnitOfWork _unitOfWork) : IServiceManager
	{
		#region Lazy Fields

		private readonly Lazy<IAuthenticationServices> authenticationServices =
			new Lazy<IAuthenticationServices>( ( ) =>
				new AuthenticationServices( _userManager, _mapper, Configuration ) );

		private readonly Lazy<ITrackServices> trackServices =
			new Lazy<ITrackServices>( ( ) => new TrackServices( _unitOfWork, _mapper ) );

		#endregion


		#region Properties

		public IAuthenticationServices AuthenticationServices => authenticationServices.Value;
		public ITrackServices TrackServices => trackServices.Value;

		#endregion
	}
}