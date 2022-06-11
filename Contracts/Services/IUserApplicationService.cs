using Entities.Models;
using Shared.DTOs.UserApplication;

namespace Contracts.Services;

public interface IUserApplicationService
{
    Task<ResponseRequest<UserApplicationDTO>> GetAllAsync();

    Task<ResponseRequest<UserApplicationDTO>> GetAsync(Guid id);

    Task<ResponseRequest<UserApplicationDTO>> PostAsync(UserApplicationRegisterDTO dto);

    Task<ResponseRequest<UserApplicationDTO>> PutAsync(Guid id, UserApplicationRegisterDTO dto);

    Task<ResponseRequest<UserApplicationDTO>> DeleteAsync(Guid id);
}