using AutoMapper;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Shared.Dtos;
using Shared.Dtos.Identity;
using Shared.Dtos.Identity.Login;
using Shared.Dtos.Identity.Register;
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

			//CreateMap<RegisterCompanyDto, CompanyUserProfile>().ReverseMap();
			//CreateMap<RegisterUserDto, RegularUserProfile>().ReverseMap();

			CreateMap<AppUser, LoggedInUserDto>()
				.ForMember(u => u.Profile,
				op => op.MapFrom(src => src.RegularProfile))
				.ReverseMap();
			//.ForMember(
			//des => des.FirstName,
			//op => op.MapFrom(
			//src => src.RegularProfile.FirstName))
			//.ForMember(
			//des => des.LastName,
			//op => op.MapFrom(
			//src => src.RegularProfile.LastName))
			//.ForMember(
			//des => des.PreferredJobTitle,
			//op => op.MapFrom(
			//src => src.RegularProfile.PreferredJobTitle))
			//.ForMember(
			//des => des.ResumeUrl,
			//op => op.MapFrom(
			//src => src.RegularProfile.ResumeUrl));

			CreateMap<AppUser, LoggedInCompanyDto>()
				.ForMember(des => des.Profile,
				op => op.MapFrom(src => src.CompanyProfile))
				.ReverseMap();


			CreateMap<CompanyUserProfile, CompanyProfileDto>().ReverseMap();
			CreateMap<RegularUserProfile, RegularUserDto>().ReverseMap();

			CreateMap<CompanyUserProfile, RegisterCompanyDto>().ReverseMap();
			CreateMap<RegularUserProfile, RegisterUserDto>().ReverseMap();

			CreateMap<AppUser, RegisterCompanyDto>().ReverseMap();
			CreateMap<AppUser, RegisterUserDto>().ReverseMap();
		}
	}
}
