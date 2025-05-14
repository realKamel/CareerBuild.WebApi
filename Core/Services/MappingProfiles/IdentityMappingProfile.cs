using AutoMapper;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Shared.Dtos;
using Shared.Dtos.Identity;
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
			CreateMap<RegisterCompanyDto, CompanyUserProfile>().ReverseMap();
			CreateMap<RegisterUserDto, RegularUserProfile>().ReverseMap();
		}
	}
}
