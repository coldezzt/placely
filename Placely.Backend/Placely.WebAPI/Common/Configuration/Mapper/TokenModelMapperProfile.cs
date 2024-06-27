using AutoMapper;
using Placely.Infrastructure.Common.Models;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class TokenModelMapperProfile : Profile
{
    public TokenModelMapperProfile()
    {
        CreateMap<TokenDto, TokenModel>();
        CreateMap<TokenModel, TokenDto>();
    }
}