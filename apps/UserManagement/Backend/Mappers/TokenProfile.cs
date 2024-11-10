using AutoMapper;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class TokenProfile: Profile
{
    public TokenProfile()
    {
        CreateMap<(string, Guid, DateTime), SessionToken>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Item2))
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Item1))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Item3));
        CreateMap<(SessionToken, User), UserFullInfoDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Item2.UserId))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Item1.Time))
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Item1.Token))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Item2.BirthDate))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Item2.Email))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item2.Name))
            .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Item2.Rol))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Item2.PhoneNumber));
        CreateMap<TokenWithoutIdDTO, SessionToken>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

    }
}
