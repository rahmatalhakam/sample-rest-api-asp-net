using System;
using AutoMapper;

namespace SampleRESTAPI.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Models.Student, Dtos.StudentDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<Dtos.StudentForCreateDto, Models.Student>();
        }
    }
}
