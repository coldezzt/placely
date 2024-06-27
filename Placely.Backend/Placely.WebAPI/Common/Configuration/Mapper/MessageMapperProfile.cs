using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class MessageMapperProfile : Profile
{
    public MessageMapperProfile()
    {
        CreateMap<MessageDto, Message>();
        CreateMap<Message, MessageDto>();
    }
}