using AutoMapper;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class ContractMapperProfile : Profile
{
    public ContractMapperProfile()
    {
        CreateMap<Reservation, Contract>()
            .ForMember(c => c.LeaseStartDate,
                opt => opt.MapFrom(r => r.EntryDate))
            .ForMember(c => c.LeaseEndDate,
                opt => opt.MapFrom(r => r.EntryDate.Add(r.Duration)));
    }
}