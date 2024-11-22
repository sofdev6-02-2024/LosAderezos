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
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        CreateMap<SubsidiaryDTO, Subsidiary>()
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        CreateMap<(SubsidiaryWithoutDTO, Guid), Subsidiary>()
            .ForMember(dest => dest.SubsidiaryId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Item1.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.Item1.CompanyId))
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Item1.Location))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Item1.Type));
        CreateMap<Subsidiary, SubsidiaryWithoutDTO>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
        CreateMap< (SubsidiaryDTO, StockFullInfoDTO), OtherSubsidiariesProductsDTO>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Item2.ProductId))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Item2.Quantity))
            .ForMember(dst => dst.SubsidiaryLocation, opt => opt.MapFrom(src => src.Item1.Location))
            .ForMember(dst => dst.SubsidiaryName, opt => opt.MapFrom(src => src.Item1.Name));
    }
}
