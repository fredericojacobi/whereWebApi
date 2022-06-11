using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly DatabaseContext _context;
    private readonly UserManager<UserApplication> _userManager;

    private IEventRepository _event;
    private IUserApplicationRepository _userApplication;

    public RepositoryWrapper(DatabaseContext context, UserManager<UserApplication> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IEventRepository Event => _event ??= new EventRepository(_context);

    public IUserApplicationRepository UserApplication => _userApplication ??= new UserApplicationRepository(_context, _userManager);
}