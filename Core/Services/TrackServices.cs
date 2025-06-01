using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Exceptions;
using Domain.Interfaces;
using Serilog;
using Services.Specifications;
using Shared.Dtos;
using Shared.Dtos.TrackModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class TrackServices(IUnitOfWork _unitOfWork, IMapper _mapper) : ITrackServices
	{
		public async Task<IEnumerable<TrackDto>> GetAllTracks(string? searchWord)
		{
			var result = await _unitOfWork
				.GetRepository<Track, int>().GetAllAsync(new TrackSpecification(searchWord));

			if (result == null || !result.Any())
			{
				Log.Error("No tracks found in the database.");
				throw new Exception("No tracks found");
			}

			var resultToReturn = _mapper
				.Map<IEnumerable<Track>, IEnumerable<TrackDto>>(result);

			Log.Information("object is {@resultToReturn}", resultToReturn);

			return resultToReturn;
		}

		public async Task<TrackDto> GetTrackById(int trackId)
		{
			var result = await _unitOfWork
				.GetRepository<Track, int>().GetByIdAsync(trackId);

			if (result == null)
			{
				throw new TrackNotFoundException(trackId);
			}

			var resultToReturn = _mapper
				.Map<Track, TrackDto>(result);

			return resultToReturn;
		}

		public async Task<IEnumerable<UserTracksDto>> GetUserEnrolledTracks(string? userEmail)
		{
			if (string.IsNullOrEmpty(userEmail))
			{
				throw new UserNotFoundException("User email not found");
			}

			var result = await _unitOfWork
				.GetRepository<UserTracks, Guid>()
				.GetAllAsync(new UserEnrolledTrackSpecification(userEmail));

			if (result == null || !result.Any())
			{
				Log.Error("No tracks found in the database.");
				throw new UserTrackNotFoundException();
			}


			var resultToReturn = _mapper
				.Map<IEnumerable<UserTracks>, IEnumerable<UserTracksDto>>(result);

			Log.Information("object is {@resultToReturn}", resultToReturn);

			return resultToReturn;
		}
	}
}