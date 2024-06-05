using AutoMapper;
using Placely.Infrastructure.Common.Models;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class AuthorizationMapperProfile : Profile
{
    public AuthorizationMapperProfile()
    {
        CreateMap<AuthorizationDto, AuthorizationModel>();
        CreateMap<AuthorizationModel, AuthorizationDto>();
    }
}