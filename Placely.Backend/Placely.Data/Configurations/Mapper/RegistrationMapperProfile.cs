using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class RegistrationMapperProfile : Profile
{
    public RegistrationMapperProfile()
    {
        CreateMap<RegistrationDto, Tenant>();
    }
}