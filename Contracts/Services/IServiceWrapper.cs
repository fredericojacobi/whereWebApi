namespace Contracts.Services;

public interface IServiceWrapper
{
    IUserApplicationService UserApplication { get; }
    
    IEventService Event { get; }
}