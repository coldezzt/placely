using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class ContractMapperProfile : Profile
{
    public ContractMapperProfile()
    {
        CreateMap<Reservation, Contract>()
            .ForMember(static c => c.LeaseStartDateTime, 
                static opt => opt.MapFrom(static r => r.EntryDate))
            .ForMember(static c => c.LeaseEndDateTime,
                static opt => opt.MapFrom(static r => r.EntryDate.Add(r.Duration)));
        
        CreateMap<Contract, ContractDto>()
            .ForMember(static dto => dto.DocxPath,
                static opt => opt.MapFrom(static c => c.FinalizedDocxFileName))
            .ForMember(static dto => dto.PdfPath,
                static opt => opt.MapFrom(static c => c.FinalizedPdfFileName));
    }
}