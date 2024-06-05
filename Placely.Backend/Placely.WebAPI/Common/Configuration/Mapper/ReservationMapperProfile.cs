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
            .ForMember(r => r.Status,
                opt =>
                    opt.MapFrom(dto => Enum.Parse<ReservationStatus>(dto.ReservationStatus)))
            .ForMember(r => r.Duration,
                opt =>
                    opt.MapFrom(dto => TimeSpan.FromDays(dto.DurationInDays)));
        
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.ReservationStatus,
                opt => 
                    opt.MapFrom(r => r.Status.ToString()))
            .ForMember(dto => dto.DurationInDays,
                opt => 
                    opt.MapFrom(r => r.Duration.Days));
    }
}