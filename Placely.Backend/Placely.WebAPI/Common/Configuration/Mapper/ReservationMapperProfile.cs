using AutoMapper;
using Placely.Domain.Common.Enums;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class ReservationMapperProfile : Profile
{
    public ReservationMapperProfile()
    {
        CreateMap<ReservationDto, Reservation>()
            .ForMember(r => r.Duration,
                opt => opt.MapFrom(dto => TimeSpan.FromDays(dto.DurationInDays)));
        
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.DurationInDays,
                opt => opt.MapFrom(r => r.Duration.Days));
    }
}