using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class TenantMapperConfiguration : Profile
{
    public TenantMapperConfiguration()
    {
        CreateMap<TenantDto, Tenant>();
        CreateMap<Tenant, TenantDto>();
    }
}