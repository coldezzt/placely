using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class ContractMapperProfile : Profile
{
    public ContractMapperProfile()
    {
        CreateMap<Reservation, Contract>()
            .ForMember(c => c.LeaseStartDateTime, 
                opt => 
                    opt.MapFrom(r => r.EntryDate))
            .ForMember(c => c.LeaseEndDateTime,
                opt => 
                    opt.MapFrom(r => r.EntryDate.Add(r.Duration)));
        
        CreateMap<Contract, ContractDto>()
            .ForMember(dto => dto.DocxPath,
                opt => 
                    opt.MapFrom(c => c.FinalizedDocxFileName))
            .ForMember(dto => dto.PdfPath,
                opt => 
                    opt.MapFrom(c => c.FinalizedPdfFileName));
    }
}