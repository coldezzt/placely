using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;

namespace Placely.Data.Configurations.Mapper;

public class ReservationMapperProfile : Profile
{
    public ReservationMapperProfile()
    {
        CreateMap<ReservationDto, Reservation>()
            .ForMember(r => r.ReservationStatus,
                opt =>
                    opt.MapFrom(dto => Enum.Parse<ReservationStatus>(dto.ReservationStatus)))
            .ForMember(r => r.Duration,
                opt =>
                    opt.MapFrom(dto => TimeSpan.FromDays(dto.DurationInDays)));
        
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.ReservationStatus,
                opt => 
                    opt.MapFrom(r => r.ReservationStatus.ToString()))
            .ForMember(dto => dto.DurationInDays,
                opt => 
                    opt.MapFrom(r => r.Duration.Days));
    }
}