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
        CreateMap<SensitiveTenantDto, Tenant>();
        CreateMap<Tenant, SensitiveTenantDto>()
            .ForMember(dto => dto.Password, opt => opt.MapFrom(_ => ""));
    }
}