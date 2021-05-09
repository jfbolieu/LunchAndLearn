using AutoMapper;
using People.Data.Entities;

namespace People.Models.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientListItem>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src=> (string.IsNullOrEmpty(src.MiddleName) ?  
                    src.FirstName + " " + src.MiddleName : src.FirstName) + " " + src.LastName)); //opt.MapFrom(new FullnamValueResolver<Client, ClientListItem>()));
            CreateMap<Client, ClientDetail>()
                .IncludeBase<Client, ClientListItem>()
                .ForMember(dest => dest.Meetings, opt => opt.MapFrom(x => x.Meetings));

            CreateMap<Meeting, MeetingListItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.DateTime.TimeOfDay))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateTime.Date))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.AgentName, opt => opt.ConvertUsing(new FullnamValueConverter<Agent>(), src => src.Agent));
        }

    }
}
