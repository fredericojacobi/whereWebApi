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

    public async Task<ResponseRequest<EventDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.Event.ReadAllEventsAsync();
            var mapperResult = _mapper.Map<ICollection<EventDTO>>(repositoryResult);
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
            if (repositoryResult is null) return new ResponseRequest<EventDTO>(false, "Not found", HttpStatusCode.NotFound);

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