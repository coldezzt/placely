using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

public class ReviewMapperProfile : Profile
{
    public ReviewMapperProfile()
    {
        CreateMap<ReviewDto, Review>();
        CreateMap<Review, ReviewDto>();
    }
}