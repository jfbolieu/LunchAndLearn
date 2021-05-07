using AutoMapper;
using People.BusinessLogic.Models;
using People.Data.Entities;

namespace People.BusinessLogic.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientListItem>()
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => src.Agent.Fullname));
            CreateMap<Client, ClientDetail>()
                .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => src.Agent.Fullname))
                .ForMember(dest => dest.Meetings, opt => opt.Ignore());

            CreateMap<Meeting, MeetingListItem>()
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.DateTime.TimeOfDay))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateTime.Date))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name));
        }

    }
}
