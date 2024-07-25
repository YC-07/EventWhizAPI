using AutoMapper;
using EventWhiz.Models.Domain;
using EventWhiz.Models.DTO;

namespace EventWhiz.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Location,LocationDTO>().ReverseMap();
            CreateMap<AddLocationRequestDTO,Location>().ReverseMap();
            CreateMap<UpdateLocationRequestDTO,Location>().ReverseMap();
            CreateMap<AddEventRequestDTO,Event>().ReverseMap();
            CreateMap<Event,EventDTO>().ReverseMap();
            CreateMap<UpdateEventRequestDTO,Event>().ReverseMap();
            CreateMap<EventType,EventTypeDTO>().ReverseMap();
        }
    }
}
