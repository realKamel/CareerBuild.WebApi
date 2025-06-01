using AbstractServices;
using AutoMapper;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Services
{
	public class ServiceManager(
		UserManager<AppUser> _userManager,
		IMapper _mapper,
		IConfiguration Configuration,
		IUnitOfWork _unitOfWork) : IServiceManager
	{
		#region Lazy Fields

		private readonly Lazy<IAuthenticationServices> _authenticationServices =
			new Lazy<IAuthenticationServices>(() => new AuthenticationServices(_userManager, _mapper, Configuration));

		private readonly Lazy<ITrackServices> _trackServices =
			new Lazy<ITrackServices>(() => new TrackServices(_unitOfWork, _mapper));

		private readonly Lazy<IJobService> _jobService =
			new Lazy<IJobService>(() => new JobService(_unitOfWork, _mapper));

		#endregion


		#region Properties

		public IAuthenticationServices AuthenticationServices => _authenticationServices.Value;
		public ITrackServices TrackServices => _trackServices.Value;
		public IJobService JobService => _jobService.Value;

		#endregion
	}
}