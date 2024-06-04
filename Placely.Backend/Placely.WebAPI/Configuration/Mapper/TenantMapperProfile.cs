using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class TenantMapperProfile : Profile
{
    public TenantMapperProfile()
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