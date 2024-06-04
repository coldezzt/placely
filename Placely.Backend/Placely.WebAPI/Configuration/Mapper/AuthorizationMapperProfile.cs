using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class AuthorizationMapperProfile : Profile
{
    public AuthorizationMapperProfile()
    {
        CreateMap<AuthorizationDto, Tenant>();
    }
}