using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap< (Stock, Product, List<Category>), StockDTO>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Item1.ProductId))
            .ForMember(dst => dst.StockId, opt => opt.MapFrom(src => src.Item1.StockId))
            .ForMember(dst => dst.Code, opt => opt.MapFrom(src => src.Item1.Code))
            .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => src.Item1.Quantity))
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.Item1.SubsidiaryId))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Item2.Name))
            .ForMember(dst => dst.ProductCode, opt => opt.MapFrom(src => src.Item2.Code))
            .ForMember(dst => dst.Notify, opt => opt.MapFrom(src => src.Item2.Notify))
            .ForMember(dst => dst.CompanyId, opt => opt.MapFrom(src => src.Item2.CompanyId))
            .ForMember(dst => dst.IncomingPrice, opt => opt.MapFrom(src => src.Item2.IncomingPrice))
            .ForMember(dst => dst.SellPrice, opt => opt.MapFrom(src => src.Item2.SellPrice))
            .ForMember(dst => dst.LowExistence, opt => opt.MapFrom(src => src.Item2.LowExistence))
            .ForMember(dst => dst.Categories, opt => opt.MapFrom(src => src.Item3));
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
