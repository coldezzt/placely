using System.Globalization;
using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class PropertyMapperProfile : Profile
{
    public PropertyMapperProfile()
    {
        CreateMap<PropertyDto, Property>()
            .ForMember(p => p.PublicationDate,
                opt => opt.MapFrom(dto => DateTime.Parse(dto.PublicationDate)))
            .ForMember(p => p.PriceList,
                opt => opt.MapFrom(dto => dto.PriceList));

        CreateMap<Property, PropertyDto>()
            .ForMember(dto => dto.PublicationDate,
                opt => opt.MapFrom(p => p.PublicationDate.ToString(CultureInfo.InvariantCulture)));
    }
}