using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<Stock, StockDTO>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dst => dst.StockId, opt => opt.MapFrom(src => src.StockId))
            .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId));
        CreateMap<StockDTO, Stock>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dst => dst.StockId, opt => opt.MapFrom(src => src.StockId))
            .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId));
        CreateMap<Stock, StockWithoutIDDTO>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId));
        CreateMap<(StockWithoutIDDTO, Guid), Stock>()
            .ForMember(dest => dest.StockId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Item1.ProductId))
            .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Item1.Code))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Item1.Quantity))
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.Item1.SubsidiaryId));

    }
}
