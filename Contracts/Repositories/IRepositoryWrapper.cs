namespace Contracts.Repositories;

public interface IRepositoryWrapper
{
    IEventRepository Event { get; }
}