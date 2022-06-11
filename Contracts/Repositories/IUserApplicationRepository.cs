using Entities.Models;

namespace Contracts.Repositories;

public interface IUserApplicationRepository : IRepositoryBase<UserApplication>
{
    Task<ICollection<UserApplication>> ReadAllUsersAsync();

    Task<UserApplication> ReadUserAsync(Guid id);

    Task<UserApplication> ReadUserByUserNameAsync(string username);

    Task<bool> CreateUserAsync(UserApplication userApplication, string password);

    Task<bool> UpdateUserAsync(UserApplication userApplication);

    Task<bool> DeleteUserAsync(UserApplication userApplication);

    Task<bool> DeleteUserAsync(Guid id);
}