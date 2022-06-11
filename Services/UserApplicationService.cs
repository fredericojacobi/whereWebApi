using System.Diagnostics;
using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;
using Shared.DTOs.UserApplication;

namespace Services;

public class UserApplicationService : IUserApplicationService
{
    private readonly IUserApplicationRepository _userApplicationRepository;
    private readonly IMapper _mapper;
    
    public UserApplicationService(IUserApplicationRepository userApplicationRepository, IMapper mapper)
    {
        _userApplicationRepository = userApplicationRepository;
        _mapper = mapper;
    }

    private readonly UserApplicationDTO user = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Frederico",
        LastName = "Jacobi",
        Birthday = new DateTime(1994, 5, 2),
        CreatedAt = DateTime.Now.AddDays(-12),
        ModifiedAt = DateTime.Now.AddHours(-5)
    };
    
    public async Task<ResponseRequest<UserApplicationDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _userApplicationRepository.ReadAllUsersAsync();
            var mapperResult = _mapper.Map<ICollection<UserApplicationDTO>>(repositoryResult);
            return new ResponseRequest<UserApplicationDTO>(user);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<UserApplicationDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<UserApplicationDTO>> GetAsync(Guid id)
    {
        try
        {
            var repositoryResult = await _userApplicationRepository.ReadUserAsync(id);
            var mapperResult = _mapper.Map<UserApplicationDTO>(repositoryResult);
            return new ResponseRequest<UserApplicationDTO>(user);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<UserApplicationDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<UserApplicationDTO>> PostAsync(UserApplicationRegisterDTO registerDTO)
    {
        try
        {
            var userApplication = _mapper.Map<UserApplication>(registerDTO);
            var repositoryResult = await _userApplicationRepository.CreateUserAsync(userApplication, userApplication.Password);
            return repositoryResult
                ? new ResponseRequest<UserApplicationDTO>(repositoryResult, "Success on register a new user.", HttpStatusCode.OK)
                : new ResponseRequest<UserApplicationDTO>(repositoryResult, "Something went wrong.", HttpStatusCode.BadRequest);

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return new ResponseRequest<UserApplicationDTO>(false, e.Message, HttpStatusCode.InternalServerError);
        }
    }

    public async Task<ResponseRequest<UserApplicationDTO>> PutAsync(Guid id, UserApplicationRegisterDTO registerDTO) =>
        new ResponseRequest<UserApplicationDTO>(false, "Method not implemented yet.", HttpStatusCode.NotImplemented);

    public async Task<ResponseRequest<UserApplicationDTO>> DeleteAsync(Guid id) =>
        new ResponseRequest<UserApplicationDTO>(false, "Method not implemented yet.", HttpStatusCode.NotImplemented);

}