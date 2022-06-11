using Contracts.Repositories;
using Entities.Models;
using Infrastructure;

namespace Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<ICollection<Event>> ReadAllEventsAsync() => await ReadAllAsync();

    public async Task<Event?> ReadEventAsync(Guid id) => await ReadById(id);

    public async Task<Event> CreateEventAsync(Event eEvent) => await CreateAsync(eEvent);
    
    public async Task<Event> UpdateEventAsync(Event eEvent) => await UpdateAsync(eEvent.Id, eEvent);

    public async Task<bool> DeleteEventAsync(Event eEvent) => await DeleteAsync(eEvent);

    public async Task<bool> DeleteEventAsync(Guid id) => await DeleteAsync(id);
}