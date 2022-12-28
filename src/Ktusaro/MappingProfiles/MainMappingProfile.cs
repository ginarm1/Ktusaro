using AutoMapper;
using Ktusaro.Core.Models;
using Ktusaro.WebApp.Dtos;

namespace Ktusaro.WebApp.MappingProfiles
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<Event, EventResponse>().ReverseMap();
            CreateMap<CreateEventRequest, Event>();
            CreateMap<EventType, string>().ConvertUsing(src => src.ToString());

            CreateMap<Sponsor, SponsorResponse>().ReverseMap();
            CreateMap<CreateSponsorRequest, Sponsor>();
            CreateMap<CompanyType, string>().ConvertUsing(src => src.ToString());

            CreateMap<Sponsorship, SponsorshipResponse>().ReverseMap();
            CreateMap<CreateSponsorshipRequest, Sponsorship>();

            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<CreateUserRegister, User>();
            CreateMap<CreateUserLogin, User>();
        }
    }
}
