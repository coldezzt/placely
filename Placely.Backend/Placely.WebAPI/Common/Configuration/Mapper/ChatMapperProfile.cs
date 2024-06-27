using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class ChatMapperProfile : Profile
{
    public ChatMapperProfile()
    {
        CreateMap<ChatDto, Chat>()
            .ForMember(c => c.Participants, 
                opt => opt.MapFrom(dto => (List<User>) null));
        
        CreateMap<Chat, ChatDto>()
            .ForMember(dto => dto.Participants,
                opt => opt.MapFrom(c => c.Participants.Select(p => p.Id).Order()));
    }
}