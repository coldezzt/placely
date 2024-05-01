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
        
        CreateMap<SensitiveTenantDto, Tenant>()
            .ForMember(t => t.Password, 
                opt => opt.MapFrom(dto => dto.NewPassword));
        CreateMap<Tenant, SensitiveTenantDto>()
            .ForMember(dto => dto.OldPassword, opt => opt.MapFrom(_ => "******"));
    }
}