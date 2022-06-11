using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Repositories;

public class UserApplicationRepository : RepositoryBase<UserApplication>, IUserApplicationRepository
{
    private readonly UserManager<UserApplication> _userManager;

    public UserApplicationRepository(DatabaseContext context, UserManager<UserApplication> userManager) : base(context) => _userManager = userManager;
    
    public async Task<ICollection<UserApplication>> ReadAllUsersAsync() => await ReadAllAsync();

    public async Task<UserApplication> ReadUserAsync(Guid id) => await _userManager.FindByIdAsync(id.ToString());

    public async Task<UserApplication> ReadUserByUserNameAsync(string username) => await _userManager.FindByNameAsync(username);

    public async Task<bool> CreateUserAsync(UserApplication userApplication, string password)
    {
        var result = await _userManager.CreateAsync(userApplication, password);
        return result.Succeeded;
    }

    public async Task<bool> UpdateUserAsync(UserApplication userApplication)
    {
        var result = await _userManager.UpdateAsync(userApplication);
        return result.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(UserApplication userApplication)
    {
        var identityResult = await _userManager.DeleteAsync(userApplication);
        return identityResult.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await ReadUserAsync(id);
        return await DeleteUserAsync(user);
    }
}