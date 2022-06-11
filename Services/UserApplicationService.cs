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
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    public UserApplicationService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseRequest<UserApplicationDTO>> GetAllAsync()
    {
        try
        {
            var repositoryResult = await _repository.UserApplication.ReadAllUsersAsync();
            var mapperResult = _mapper.Map<ICollection<UserApplicationDTO>>(repositoryResult);
            return new ResponseRequest<UserApplicationDTO>(mapperResult);
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
            var repositoryResult = await _repository.UserApplication.ReadUserAsync(id);
            var mapperResult = _mapper.Map<UserApplicationDTO>(repositoryResult);
            return new ResponseRequest<UserApplicationDTO>(mapperResult);
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
            var repositoryResult = await _repository.UserApplication.CreateUserAsync(userApplication, userApplication.Password);
            return repositoryResult
                ? new ResponseRequest<UserApplicationDTO>(repositoryResult, "Success on register new user.", HttpStatusCode.OK)
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