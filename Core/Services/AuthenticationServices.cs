using AbstractServices;
using AutoMapper;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos;
using Shared.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class AuthenticationServices(
		UserManager<AppUser> _userManager,
		IMapper _mapper,
		IUnitOfWork _unitOfWork)
		 : IAuthenticationServices 
	{
		public async Task<LoggedInCompany> LoginCompanyAsync(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);

			if (user == null)
			{
				//TODO
				//throw new UserNotFoundException(login.Email);
			}

			var validPassword = await _userManager
				.CheckPasswordAsync(user!, loginDto.Password);

			if (!validPassword)
			{
				//TODO
				//throw new WrongLoginException();
			}
			//TODO
			var result = new LoggedInCompany()
			{
				Email = user.Email ?? loginDto.Email,
				Size = user.CompanyProfile.Size,
				CompanyName = user.CompanyProfile.CompanyName,
				Industry = user.CompanyProfile.Industry,
				PictureUrl = user.PictureUrl,
				WebsiteUrl = user.CompanyProfile.WebsiteUrl,
				Address = _mapper.Map<AddressDto>(user.Address),
				Token = "Token",
			};
			return result;
		}

		public async Task<LoggedInUser> LoginRegularUserAsync(LoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null)
			{
				//TODO
				//throw new UserNotFoundException(login.Email);
			}
			var validPassword = await _userManager
				.CheckPasswordAsync(user!, loginDto.Password);

			if (!validPassword)
			{
				//TODO
				//throw new WrongLoginException();
			}
			var result = new LoggedInUser()
			{
				Email = user.Email ?? loginDto.Email,
				FirstName = user.RegularProfile.FirstName,
				LastName = user.RegularProfile.LastName,
				EducationLevel = user.RegularProfile.EducationLevel.ToString(),
				PictureUrl = user.PictureUrl,
				PreferredJobTitle = user.RegularProfile.PreferredJobTitle,
				ResumeUrl = user.RegularProfile.ResumeUrl,
				UserGoal = user.RegularProfile.UserGoal,
				Address = _mapper.Map<AddressDto>(user.Address),
				Token = "Token",
			};
			return result;
		}

		public async Task<bool> RegisterCompanyUserAsync(RegisterCompanyDto companyDto)
		{
			var user = new AppUser()
			{
				Email = companyDto.Email,
				UserName = companyDto.UserName,
				PhoneNumber = companyDto.PhoneNumber,
				Address = _mapper.Map<Address>(companyDto.Address)
			};

			var result = await _userManager.CreateAsync(user, companyDto.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				throw new Exception("Register fails"); // BadRequestException(errors);
			}


			var companyProfile = _mapper.Map<CompanyUserProfile>(companyDto);
			companyProfile.AppUserId = user.Id;


			await _unitOfWork.CompanyUserRepository.AddAsync(companyProfile);


			return await _unitOfWork.SaveChangesAsync() > 0;
		}

		public async Task<bool> RegisterRegularUserAsync(RegisterUserDto userDto)
		{
			var user = new AppUser()
			{
				Email = userDto.Email,
				UserName = userDto.UserName,
				PhoneNumber = userDto.PhoneNumber,
				Address = _mapper.Map<Address>(userDto.Address),
			};

			var result = await _userManager.CreateAsync(user, userDto.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				throw new Exception("Register fails"); // BadRequestException(errors);
			}


			var regularUser = _mapper.Map<RegularUserProfile>(userDto);
			regularUser.AppUserId = user.Id;


			await _unitOfWork.RegularUserRepository.AddAsync(regularUser);


			return await _unitOfWork.SaveChangesAsync() > 0;
		}
	}
}
