using AutoMapper;
using Entities.Models;
using Shared.DTOs.UserApplication;

namespace Entities.MapProfiles;

public class UserApplicationProfile : Profile
{
    public UserApplicationProfile()
    {
        CreateMap<UserApplication, UserApplicationDTO>().ReverseMap();
        CreateMap<UserApplication, UserApplicationRegisterDTO>().ReverseMap();
        CreateMap<UserApplicationRegisterDTO, UserApplication>();
    }
}