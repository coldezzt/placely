using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class AuthorizationMapperProfile : Profile
{
    public AuthorizationMapperProfile()
    {
        CreateMap<AuthorizationDto, Tenant>();
    }
}