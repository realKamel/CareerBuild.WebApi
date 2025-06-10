using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Serilog;
using Services.Specifications;
using Shared.Dtos.TrackModule;
using System;
using System.Net.Http.Json;

namespace Services
{
	public class TrackServices(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpClientFactory _httpClient, IDistributedCache _distributedCache) : ITrackServices
	{
		public async Task<IEnumerable<TrackDto>> GetAllTracks(string? searchWord)
		{
			IEnumerable<Track>? result = await _unitOfWork
				.GetRepository<Track, int>().GetAllAsync(new TrackSpecification(searchWord));

			TrackDto? aiResponse;

			if (result?.Any() == false)
			{
				Log.Warning("No tracks are found in Local Database.");

				aiResponse = await GetTrackDetailsFromAiApi<TrackDto>(searchWord);

				if (aiResponse == null)
				{
					Log.Error("AI response is null for search word: {SearchWord}", searchWord);
					Log.Error("No tracks found in the database or AI response is null.");
					throw new TrackNotFoundException("Track not found");
				}
				return [aiResponse];
			}

			var resultToReturn = _mapper
				.Map<IEnumerable<Track>, IEnumerable<TrackDto>>(result);

			Log.Information("object is {@resultToReturn}", resultToReturn);

			return resultToReturn;
		}

		public async Task<DetailedTrackDto> GetTrackById(int trackId)
		{
			var result = await _unitOfWork.GetRepository<Track, int>()
									.GetByIdAsync(new TrackSpecification(trackId));

			if (result == null)
			{
				throw new TrackNotFoundException(trackId);
			}

			var resultToReturn = _mapper.Map<Track, DetailedTrackDto>(result);

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
		public async Task<TEntity> GetTrackDetailsFromAiApi<TEntity>(string searchWord)
		{
			var client = _httpClient.CreateClient("AiHttpClient");

			var response = await client.GetAsync($"api/track?search_query={searchWord}");

			if (!response.IsSuccessStatusCode)
			{
				Log.Error("Failed to fetch track details from AI API. Status code: {StatusCode}",
				response.StatusCode);
				throw new HttpRequestException($"Failed to fetch track details: {response.ReasonPhrase}");
			}
			var aiTrackResponse = await response.Content.ReadFromJsonAsync<AiCreatedTrackDto>();

			Log.Information("AI Track Response: {@AiTrackResponse}", aiTrackResponse);

			if (aiTrackResponse == null)
			{
				Log.Error("AI Track response is null.");
				throw new TrackNotFoundException("Track not found in AI response");
			}
			var track = _mapper.Map<AiCreatedTrackDto, Track>(aiTrackResponse);

			await _unitOfWork.GetRepository<Track, int>().AddAsync(track);
			await _unitOfWork.SaveChangesAsync();
			return _mapper.Map<AiCreatedTrackDto, TEntity>(aiTrackResponse);
		}

		public async Task<bool> DeleteTrack(int trackId)
		{
			var track = await _unitOfWork.GetRepository<Track, int>().GetByIdAsync(trackId);

			if (track == null)
			{
				throw new TrackNotFoundException(trackId);
			}

			_unitOfWork.GetRepository<Track, int>().Remove(track);

			return await _unitOfWork.SaveChangesAsync() > 1;
		}
	}
}