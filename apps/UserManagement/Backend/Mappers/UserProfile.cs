using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class UserProfile : Profile 
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<(UserWithoutIdDTO, Guid), User>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item2));
        CreateMap<User, UserWithoutIdDTO>();

    }
}
