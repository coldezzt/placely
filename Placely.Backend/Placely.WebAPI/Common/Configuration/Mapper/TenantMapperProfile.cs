using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class TenantMapperProfile : Profile
{
    public TenantMapperProfile()
    {
        CreateMap<TenantDto, User>();
        CreateMap<User, TenantDto>();
        
        CreateMap<SensitiveTenantDto, User>()
            .ForMember(t => t.Password, 
                opt => opt.MapFrom(dto => dto.NewPassword));
        CreateMap<User, SensitiveTenantDto>()
            .ForMember(dto => dto.OldPassword, opt => opt.MapFrom(_ => "******"));
    }
}