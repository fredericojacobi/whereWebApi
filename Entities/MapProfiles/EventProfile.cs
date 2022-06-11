using AutoMapper;
using Entities.Models;
using Shared.DTOs.Event;

namespace Entities.MapProfiles;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDTO>().ReverseMap();
        CreateMap<EventRegisterDTO, Event>().ReverseMap();
        
    }
}