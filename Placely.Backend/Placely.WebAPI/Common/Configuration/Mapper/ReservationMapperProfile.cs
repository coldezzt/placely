using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class ReservationMapperProfile : Profile
{
    public ReservationMapperProfile()
    {
        CreateMap<ReservationDto, Reservation>()
            .ForMember(r => r.Duration,
                opt => opt.MapFrom(dto => TimeSpan.FromDays(dto.DurationInDays)))
            .ForMember(r => r.Participants,
                opt => opt.MapFrom(dto => new List<User>
                {
                    new() {Id = dto.TenantId},
                    new() {Id = dto.LandlordId}
                }));
        
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.DurationInDays,
                opt => opt.MapFrom(r => r.Duration.Days))
            .ForMember(dto => dto.TenantId,
                opt => opt.MapFrom(r => r.Participants[0].Id))
            .ForMember(dto => dto.LandlordId,
                opt => opt.MapFrom(r => r.Participants[1].Id));
    }
}