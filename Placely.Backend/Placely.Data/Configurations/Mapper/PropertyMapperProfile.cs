using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

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