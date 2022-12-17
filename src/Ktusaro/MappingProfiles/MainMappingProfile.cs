using AutoMapper;
using Ktusaro.Core.Models;
using Ktusaro.WebApp.Dtos;

namespace Ktusaro.WebApp.MappingProfiles
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<CreateEventDto, Event>().ReverseMap();
        }
    }
}
