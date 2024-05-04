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
                    opt.MapFrom(dto => Enum.Parse<ReservationStatus>(dto.ReservationStatus)));
        
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.ReservationStatus,
                opt => 
                    opt.MapFrom(r => r.ReservationStatus.ToString()));
    }
}