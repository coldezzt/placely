using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

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