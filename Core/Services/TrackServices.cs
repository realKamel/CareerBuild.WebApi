using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
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
		public async Task<IEnumerable<TrackDto>> GetAllTracks( )
		{
			var result = await _unitOfWork
				.GetRepository<Track, int>().GetAllAsync();

			if ( result == null || !result.Any() )
			{
				throw new Exception( "Internal Error" );
			}

			var resultToReturn = _mapper
			.Map<IEnumerable<Track>, IEnumerable<TrackDto>>( result );

			return resultToReturn;
		}

		public async Task<TrackDto> GetTrackById(int trackId)
		{

			var result = await _unitOfWork
				.GetRepository<Track, int>().GetByIdAsync( trackId );

			if ( result == null )
			{
				throw new TrackNotFoundException( trackId );
			}

			var resultToReturn = _mapper
				.Map<Track, TrackDto>( result );

			return resultToReturn;
		}
	}
}
