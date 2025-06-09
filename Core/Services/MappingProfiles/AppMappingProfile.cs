using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Shared.Dtos;
using Shared.Dtos.TrackModule;
using Shared.Dtos.JobModule;
using Shared.Dtos.SkillModule;
using Domain.Entities.Common;
using Shared.Dtos.Common;


namespace Services.MappingProfiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			#region Track
			CreateMap<Track, TrackDto>();
			CreateMap<Track, DetailedTrackDto>().ReverseMap();
			CreateMap<TrackPrerequisites, TrackPrerequisitesDto>();
			CreateMap<UserTracks, UserTracksDto>();
			CreateMap<DifficultyLevel, DifficultyLevelDto>();

			CreateMap<AiCreatedTrackDto, Track>()
				.ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.URL))
				.ForMember(des => des.Description, opt => opt.MapFrom(src => string.Join(" ", src.Description))).ReverseMap();


			CreateMap<AiCreatedTrackDto, TrackDto>()
				.ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.URL))
				.ForMember(des => des.Description, opt => opt.MapFrom(src => string.Join(" ", src.Description))).ReverseMap();

			CreateMap<AiCreatedCourseDto, Course>()
				.ForMember(dest => dest.DurationInHours, opt => opt.MapFrom(src => int.Parse(src.Duration)))
				.ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(e => new Skill { Name = e })))
				.ForMember(dest => dest.CourseUrl, opt => opt.MapFrom(src => src.URL)).ReverseMap();

			#endregion

			#region Skill
			CreateMap<Skill, SkillDto>().ReverseMap();
			CreateMap<CreatedSkillDto, Skill>();
			CreateMap<Exam, ExamDto>();
			CreateMap<Course, CourseDto>();

			#endregion


			#region Job
			CreateMap<Job, JobDto>().ReverseMap();
			CreateMap<CreatedJobDto, Job>();

			CreateMap<UserJobs, PostedJobApplication>()
			.ForMember(des => des.Id, opt => opt.MapFrom(src => src.JobId))
			.ForMember(des => des.Name, opt => opt.MapFrom(src => src.Job.Name))
			.ForMember(des => des.Description, opt => opt.MapFrom(src => src.Job.Description))
			.ForMember(des => des.Location, opt => opt.MapFrom(src => src.Job.Location))
			.ForMember(des => des.EmploymentType, opt => opt.MapFrom(src => src.Job.EmploymentType))
			.ForMember(des => des.CompanyName, opt => opt.MapFrom(src => src.Job.CompanyName))
			.ForMember(des => des.CompanyLogoUrl, opt => opt.MapFrom(src => src.Job.CompanyLogoUrl))
			.ForMember(des => des.Skills, opt => opt.MapFrom(src => src.Job.Skills))
			.ReverseMap();

			#endregion


		}
	}
}


