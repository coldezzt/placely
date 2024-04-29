using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class ReservationMapperConfiguration : Profile
{
    public ReservationMapperConfiguration()
    {
        CreateMap<ReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDto>();
    }
}