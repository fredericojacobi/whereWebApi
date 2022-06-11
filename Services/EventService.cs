using System.Diagnostics;
using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;
using Shared.DTOs.Event;

namespace Services;

public class EventService : IEventService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public EventService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseRequest<EventDTO>> GetAllAsync(int? max_records)
    {
        try
        {
            var repositoryResult = await _repository.Event.ReadAllEventsAsync();
            var mapperResult = _mapper.Map<ICollection<EventDTO>>(repositoryResult);

            if (max_records.HasValue)
            {
                var eEvents = new List<EventDTO>();
                var rand = new Random();
                for (int i = 0; i < max_records; i++)
                {
                    var number = (i + 1) * rand.Next(max_records.Value * 5);
                    var startDate = DateTime.Now.AddDays(number);
                    var endDate = startDate.AddHours(4);

                    eEvents.Add(new()
                    {
                        Id = Guid.NewGuid(),
                        LocationId = Guid.NewGuid(),
                        EventTypeId = Guid.NewGuid(),
                        Name = $"Nome do Evento {number}",
                        Title = $"Titulo do Evento {number}",
                        ShortDescription = $"Descrição curta do evento {number} com poucos caracteres",
                        LongDescription = $"Descrição longa do evento {number} com vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários, vários... caracteres",
                        PriceRate = "5",
                        StartDate = startDate,
                        EndDate = endDate,
                        IsCovered = number % 2 == 0,
                        MinAge = 15 + i,
                        Likes = rand.Next(50000),
                        Shares = rand.Next(50000),
                        Participants = rand.Next(50000)
                    });
                }
                return new ResponseRequest<EventDTO>(eEvents);
            }

            return new ResponseRequest<EventDTO>(mapperResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<EventDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<EventDTO>> GetAsync(Guid id)
    {
        try
        {
            var repositoryResult = await _repository.Event.ReadEventAsync(id);
            if (repositoryResult is null)
                return new ResponseRequest<EventDTO>(false, "Not found", HttpStatusCode.NotFound);

            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ResponseRequest<EventDTO>(mapperResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<EventDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<EventDTO>> PostAsync(EventRegisterDTO registerDTO)
    {
        try
        {
            var eEvent = _mapper.Map<Event>(registerDTO);
            var repositoryResult = await _repository.Event.CreateEventAsync(eEvent);
            var mapperResult = _mapper.Map<EventDTO>(repositoryResult);
            return new ResponseRequest<EventDTO>(mapperResult);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<EventDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<EventDTO>> PutAsync(Guid id, EventRegisterDTO eventDTO) =>
        new ResponseRequest<EventDTO>(false, "Method not implemented yet.", HttpStatusCode.NotImplemented);

    public async Task<ResponseRequest<EventDTO>> DeleteAsync(Guid id) =>
        new ResponseRequest<EventDTO>(false, "Method not implemented yet.", HttpStatusCode.NotImplemented);
}