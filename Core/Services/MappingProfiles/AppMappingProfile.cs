using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Shared.Dtos;
using Shared.Dtos.TrackModule;

namespace Services.MappingProfiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Track, TrackDto>();
			CreateMap<Phase, PhaseDto>();
			CreateMap<Exam, ExamDto>();
			CreateMap<Course, CourseDto>();
			CreateMap<PhaseSkills, SkillDto>();
			CreateMap<UserTracks, UserTracksDto>();
			CreateMap<Job, JobDto>().ReverseMap();
			CreateMap<Skill, SkillDto>().ReverseMap();
			CreateMap<CreatedJobDto, Job>();
			CreateMap<CreatedSkillDto, Skill>();
		}
	}
}
