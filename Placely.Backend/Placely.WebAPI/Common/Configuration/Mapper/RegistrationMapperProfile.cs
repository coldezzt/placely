using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class RegistrationMapperProfile : Profile
{
    public RegistrationMapperProfile()
    {
        CreateMap<RegistrationDto, User>();
    }
}