using System;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Common;
using Shared.Dtos.TrackModule;

namespace Services.MappingProfiles
{
	public class CustomCourseDifficultyLevelResolver : IValueResolver<AiCreatedCourseDto, Course, DifficultyLevel>
	{
		public DifficultyLevel Resolve(AiCreatedCourseDto source, Course destination, DifficultyLevel destMember, ResolutionContext context)
		{
			// Attempt to parse the difficulty level string into the DifficultyLevel enum
			if (Enum.TryParse<DifficultyLevel>(source.courseDifficulty.Split(" ")[0], true, out var level))
			{
				return level;
			}

			// Default to a specific DifficultyLevel if parsing fails
			return DifficultyLevel.None; // Replace with your default value
		}
	}
	public class CustomTrackDifficultyLevelResolver : IValueResolver<AiCreatedTrackDto, Track, DifficultyLevel>
	{
		public DifficultyLevel Resolve(AiCreatedTrackDto source, Track destination, DifficultyLevel destMember, ResolutionContext context)
		{
			// Attempt to parse the difficulty level string into the DifficultyLevel enum
			if (Enum.TryParse<DifficultyLevel>(source?.difficultyLevel?.Split(" ")[0], true, out var level))
			{
				return level;
			}

			// Default to a specific DifficultyLevel if parsing fails
			return DifficultyLevel.None; // Replace with your default value
		}
	}
	// public class CustomTrackDtoDifficultyLevelResolver : IValueResolver<AiCreatedTrackDto, TrackDto, DifficultyLevel>
	// {
	// 	public DifficultyLevel Resolve(AiCreatedTrackDto source, TrackDto destination, DifficultyLevel destMember, ResolutionContext context)
	// 	{
	// 		// Attempt to parse the difficulty level string into the DifficultyLevel enum
	// 		if (Enum.TryParse<DifficultyLevel>(source?.difficultyLevel?.Split(" ")[0], true, out var level))
	// 		{
	// 			return level;
	// 		}

	// 		// Default to a specific DifficultyLevel if parsing fails
	// 		return DifficultyLevel.None; // Replace with your default value
	// 	}
	// }


	public class CustomTrackDtoDifficultyLevelResolver : IValueResolver<AiCreatedTrackDto, TrackDto, string>
	{
		public string Resolve(AiCreatedTrackDto source, TrackDto destination, string destMember, ResolutionContext context)
		{
			if (Enum.TryParse<DifficultyLevel>(source?.difficultyLevel?.Split(" ")[0], true, out var level))
			{
				return level.ToString();
			}

			// Default to a specific DifficultyLevel if parsing fails
			return DifficultyLevel.None.ToString(); // Replace with your default value


			// Implement the logic to resolve DifficultyLevel here

		}
	}
}
