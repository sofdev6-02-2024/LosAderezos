using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDTO>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId));
        CreateMap<CompanyDTO, Company>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId));
        CreateMap<Company, CompanyWithoutIDDTO>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId));
        CreateMap< (CompanyWithoutIDDTO, Guid), Company>()
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.Item1.UserId));
    }
}
