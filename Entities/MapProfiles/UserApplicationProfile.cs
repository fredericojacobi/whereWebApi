using AutoMapper;
using Entities.Models;
using Shared.DTOs.UserApplication;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationDTO>();
        CreateMap<UserApplication, UserApplicationRegisterDTO>();
    }
}