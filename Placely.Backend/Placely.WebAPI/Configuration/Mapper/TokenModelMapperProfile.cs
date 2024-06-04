using AutoMapper;
using Placely.Application.Models;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class TokenModelMapperProfile : Profile
{
    public TokenModelMapperProfile()
    {
        CreateMap<TokenDto, TokenModel>();
        CreateMap<TokenModel, TokenDto>();
    }
}