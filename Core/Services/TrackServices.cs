using AbstractServices;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Serilog;
using Services.Specifications;
using Shared.Dtos;
using Shared.Dtos.TrackModule;
using System;
using System.Net.Http.Json;
using System.Text.Json;

namespace Services
{
	public class TrackServices(IUnitOfWork _unitOfWork, IMapper _mapper, IHttpClientFactory _httpClient, IDistributedCache _distributedCache) : ITrackServices
	{
		public async Task<IEnumerable<TrackDto>> GetAllTracks()
		{
			var tracks = await _unitOfWork.GetRepository<Track, int>().GetAllAsync();
			return _mapper.Map<IEnumerable<Track>, IEnumerable<TrackDto>>(tracks);
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

		public async Task<TrackDto> SearchTrackByAi(string searchWord)
		{
			var repo = _unitOfWork.GetRepository<Track, int>();

			// we get all the track with its name and id in list and search word
			var existedTracks = await repo.GetAllAsync();
			var data = existedTracks.Select(t => new { t.Id, t.Name });

			var itemsList = new List<Item>();
			foreach (var e in data)
			{
				itemsList.Add(new Item() { Id = e.Id, Name = e.Name });
			}
			var aiRequest = new AiSearchTrackRequestDto() { Search_query = searchWord, Items = itemsList };

			// send this ai client to determine if the track exist in data base or not
			var aiCheck = await CheckIfTrackExists(aiRequest);

			// if yes we get data from database
			if (aiCheck.HasValue)
			{
				var dbResult = await repo.GetByIdAsync(new TrackSpecification(aiCheck.Value));

				if (dbResult is null)
				{
					throw new TrackNotFoundException("No Track Where Found");
				}

				return _mapper.Map<Track, TrackDto>(dbResult);
			}
			else
			{
				var aiResponse = await GetTrackDetailsFromAiApi(searchWord);

				if (aiResponse == null)
				{
					Log.Error("AI response is null for search word: {SearchWord}", searchWord);
					Log.Error("No tracks found in the database or AI response is null.");
					throw new TrackNotFoundException("Track not found");
				}
				var track = _mapper.Map<AiCreatedTrackDto, Track>(aiResponse);
				await repo.AddAsync(track);

				await _unitOfWork.SaveChangesAsync();

				return _mapper.Map<TrackDto>(track);
			}
		}


		private async Task<int?> CheckIfTrackExists(AiSearchTrackRequestDto data)
		{
			var client = _httpClient.CreateClient("AiHttpClient");

			try
			{
				var response = await client.PostAsJsonAsync("api/isThere", data);

				if (!response.IsSuccessStatusCode)
				{
					Log.Error("Failed to fetch track: {StatusCode} - {ReasonPhrase}",
						response.StatusCode, response.ReasonPhrase);
					return null; // or throw, depending on your error handling strategy
				}

				var result = await response.Content.ReadFromJsonAsync<AiSearchTrackResponseDto>();
				return result?.id;
			}
			catch (HttpRequestException ex)
			{
				Log.Error(ex, "HTTP request failed when checking if track exists");
				return null; // or rethrow
			}
			catch (JsonException ex)
			{
				Log.Error(ex, "Failed to deserialize response when checking if track exists");
				return null; // or rethrow
			}
			catch (TaskCanceledException ex)
			{
				Log.Error(ex, "Request timeout when checking if track exists");
				return null; // or rethrow
			}
		}

		public async Task<AiCreatedTrackDto> GetTrackDetailsFromAiApi(string searchWord)
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
			return aiTrackResponse;
		}
	}
}