using AbstractServices;
using AutoMapper;
using Domain.Entities.Common;
using Domain.Entities.IdentityModule;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		private async Task<TEntity> LogInHelper<TEntity>(AppUser? user, LoginDto loginDto)
			where TEntity : LoggedIn
		{
			if (user == null)
			{
				throw new UserNotFoundException(loginDto.Email);
			}

			var validPassword = await _userManager
				.CheckPasswordAsync(user!, loginDto.Password);

			if (!validPassword)
			{
				throw new WrongLoginException();
			}

			var result = _mapper.Map<TEntity>(user);

			result.Token = "Token";

			return result;
		}

		private async Task<AppUser> RegisterHelper<TEntity>(TEntity registerDto)
		where TEntity : RegisterBaseDto
		{
			var user = _mapper.Map<AppUser>(registerDto);

			var result = await _userManager.CreateAsync(user, registerDto.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description).ToList();
				throw new BadRequestException(errors);
			}
			if (user == null)
			{
				throw new Exception("internal Error");
			}
			return user;
		}

		public async Task<LoggedInUserDto> LoginRegularUserAsync(LoginDto loginDto)
		{
			//var user = await _userManager.FindByEmailAsync(loginDto.Email);
			var user = await _userManager.Users
				.Include(u => u.RegularProfile)
				.FirstOrDefaultAsync(x => x.NormalizedEmail == loginDto.Email.ToUpper());

			return await LogInHelper<LoggedInUserDto>(user, loginDto);
		}

		public async Task<LoggedInCompanyDto> LoginCompanyAsync(LoginDto loginDto)
		{
			var user = await _userManager.Users
				.Include(u => u.CompanyProfile)
				.FirstOrDefaultAsync(x => x.NormalizedEmail == loginDto.Email.ToUpper());

			return await LogInHelper<LoggedInCompanyDto>(user, loginDto);
		}

		public async Task<bool> RegisterCompanyUserAsync(RegisterCompanyDto companyDto)
		{
			// it's not possible to have null user as the function will throw exception
			var user = await RegisterHelper<RegisterCompanyDto>(companyDto);

			var companyProfile = _mapper.Map<CompanyUserProfile>(companyDto);

			companyProfile.AppUserId = user.Id; // nav property

			try
			{
				await _unitOfWork.CompanyUserRepository.AddAsync(companyProfile);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return await _unitOfWork.SaveChangesAsync() > 0;
		}

		public async Task<bool> RegisterRegularUserAsync(RegisterUserDto userDto)
		{
			var user = await RegisterHelper<RegisterUserDto>(userDto);

			var regularUser = _mapper.Map<RegularUserProfile>(userDto);

			regularUser.AppUserId = user.Id;

			try
			{

				await _unitOfWork.RegularUserRepository.AddAsync(regularUser);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return await _unitOfWork.SaveChangesAsync() > 0;
		}
	}
}
