using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class ReviewMapperProfile : Profile
{
    public ReviewMapperProfile()
    {
        CreateMap<ReviewDto, Review>();
        CreateMap<Review, ReviewDto>();
    }
}