using Entities.Models;
using Shared.DTOs.Event;

namespace Contracts.Services;

public interface IEventService
{
    Task<ResponseRequest<EventDTO>> GetAllAsync();

    Task<ResponseRequest<EventDTO>> GetAsync(Guid id);

    Task<ResponseRequest<EventDTO>> PostAsync(EventRegisterDTO registerDTO);

    Task<ResponseRequest<EventDTO>> PutAsync(Guid id, EventRegisterDTO eventDTO);

    Task<ResponseRequest<EventDTO>> DeleteAsync(Guid id);
}