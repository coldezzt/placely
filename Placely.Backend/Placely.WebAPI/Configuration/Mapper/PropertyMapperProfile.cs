using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class PropertyMapperProfile : Profile
{
    public PropertyMapperProfile()
    {
        CreateMap<PropertyDto, Property>()
            .ForMember(p => p.PriceList,
                opt => 
                    opt.MapFrom(dto => new PriceList
                        {
                            PeriodShort = dto.ShortPeriodPayment,
                            PeriodMedium = dto.MediumPeriodPayment,
                            PeriodLong = dto.LongPeriodPayment
                        })
                    );

        CreateMap<Property, PropertyDto>()
            .ForMember(dto => dto.ShortPeriodPayment,
                opt => 
                    opt.MapFrom(p => p.PriceList.PeriodShort))
            .ForMember(dto => dto.MediumPeriodPayment,
                opt => 
                    opt.MapFrom(p => p.PriceList.PeriodMedium))
            .ForMember(dto => dto.LongPeriodPayment,
                opt => 
                    opt.MapFrom(p => p.PriceList.PeriodLong));
    }
}