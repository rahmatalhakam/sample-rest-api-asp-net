using System;
using AutoMapper;

namespace SampleRESTAPI.Profiles
{
    public class CourseProfiles : Profile
    {
        public CourseProfiles()
        {
            CreateMap<Models.Course, Dtos.CourseDto>()
                .ForMember(dest => dest.TotalHours,
                opt => opt.MapFrom(src => Convert.ToDecimal(src.Credits)*1.5m));
            CreateMap<Dtos.CourseForCreateDto, Models.Course>();
        }
    }
}
