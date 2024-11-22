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
        CreateMap<UserDTO, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        CreateMap<(UserWithoutIdDTO, Guid), User>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Item1.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Item1.Rol))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Item1.BirthDate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Item1.PhoneNumber));;
        CreateMap<User, UserWithoutIdDTO>();
        CreateMap<(User, UpdateUserDTO), User>()
            .ForMember(dest => dest.UserId, expression => expression.MapFrom(src => src.Item1.UserId))
            .ForMember(dest => dest.Email, expression => expression.MapFrom(src => src.Item1.Email))
            .ForMember(dest => dest.Rol, expression => expression.MapFrom(src => src.Item1.Rol))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Item2.Name))
            .ForMember(dest => dest.PhoneNumber, expression => expression.MapFrom(src => src.Item2.PhoneNumber))
            .ForMember(dest => dest.BirthDate, expression => expression.MapFrom(src => src.Item2.BirthDate));



    }
}
