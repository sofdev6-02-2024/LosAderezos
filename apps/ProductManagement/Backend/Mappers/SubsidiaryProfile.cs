using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class SubsidiaryProfile: Profile
{
    public SubsidiaryProfile()
    {
        CreateMap<Subsidiary, SubsidiaryDTO>()
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        CreateMap<SubsidiaryDTO, Subsidiary>()
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        CreateMap<(SubsidiaryWithoutDTO, Guid), Subsidiary>()
            .ForMember(dest => dest.SubsidiaryId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.Item1.CompanyId))
            .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Item1.Latitude))
            .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Item1.Longitude))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Item1.Type));
        CreateMap<Subsidiary, SubsidiaryWithoutDTO>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dst => dst.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dst => dst.Longitude, opt => opt.MapFrom(src => src.Longitude))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
    }
}
