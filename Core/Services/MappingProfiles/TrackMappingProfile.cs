using AutoMapper;
using Domain.Entities;
using Domain.Entities.JoinEntities;
using Shared.Dtos;
using Shared.Dtos.TrackModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
	internal class TrackMappingProfile : Profile
	{
		public TrackMappingProfile( )
		{
			CreateMap<Track, TrackDto>();
			CreateMap<Phase, PhaseDto>();
			CreateMap<Exam, ExamDto>();
			CreateMap<Course, CourseDto>();
			CreateMap<PhaseSkills, SkillDto>();
		}
	}
}
