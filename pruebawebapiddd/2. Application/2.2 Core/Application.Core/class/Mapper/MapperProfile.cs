using AutoMapper;
using Domain.Core;

namespace Application.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Departments, DepartmentsDto>().ReverseMap();
            CreateMap<Cities, CitiesDto>().ReverseMap();
        }
    }
}