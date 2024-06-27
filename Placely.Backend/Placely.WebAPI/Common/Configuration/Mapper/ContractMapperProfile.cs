using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class ContractMapperProfile : Profile
{
    public ContractMapperProfile()
    {
        CreateMap<Reservation, Contract>();
            
        CreateMap<Contract, ContractDto>()
            .ForMember(dto => dto.DocxPath,
                opt => opt.MapFrom(c => c.FinalizedDocxFileName))
            .ForMember(dto => dto.PdfPath,
                opt => opt.MapFrom(c => c.FinalizedPdfFileName));
    }
}