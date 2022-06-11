namespace Contracts.Repositories;

public interface IRepositoryWrapper
{
    IUserApplicationRepository UserApplication { get; }

    IEventRepository Event { get; }
}