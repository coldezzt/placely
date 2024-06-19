using AutoMapper;
using Placely.Domain.Entities;
using Placely.WebAPI.Dto;

namespace Placely.WebAPI.Common.Configuration.Mapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
        
        CreateMap<SensitiveUserDto, User>()
            .ForMember(t => t.Password, 
                opt => opt.MapFrom(dto => dto.NewPassword));
        CreateMap<User, SensitiveUserDto>()
            .ForMember(dto => dto.OldPassword, opt => opt.MapFrom(_ => "******"));
    }
}