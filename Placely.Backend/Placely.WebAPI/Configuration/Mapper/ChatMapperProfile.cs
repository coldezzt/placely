using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Configuration.Mapper;

public class ChatMapperProfile : Profile
{
    public ChatMapperProfile()
    {
        CreateMap<ChatDto, Chat>()
            .ForMember(c => c.SecondUserId,
                opt => opt.MapFrom(dto => dto.OtherUserId));

        CreateMap<Chat, ChatDto>()
            .ForMember(dto => dto.OtherUserId,
                opt => opt.MapFrom(c => c.SecondUserId));
    }
}