namespace Contracts.Services;

public interface IServiceWrapper
{
    IEventService Event { get; }
}