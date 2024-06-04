using AutoMapper;
using Placely.Data.Dtos;
using Placely.Data.Entities;

namespace Placely.Data.Configurations.Mapper;

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