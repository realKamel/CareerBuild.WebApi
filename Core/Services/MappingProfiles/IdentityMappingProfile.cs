using AutoMapper;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Shared.Dtos;
using Shared.Dtos.IdentityModule;
using Shared.Dtos.IdentityModule.Login;
using Shared.Dtos.IdentityModule.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
	public class IdentityMappingProfile : Profile
	{
		public IdentityMappingProfile()
		{
			CreateMap<Address, AddressDto>().ReverseMap();

			CreateMap<CompanyUser, LoggedInCompanyDto>().ReverseMap();
			CreateMap<RegularUser, LoggedInUserDto>().ReverseMap();

			CreateMap<CompanyUser, RegisterCompanyDto>().ReverseMap();
			CreateMap<RegularUser, RegisterUserDto>().ReverseMap();
		}
	}
}
