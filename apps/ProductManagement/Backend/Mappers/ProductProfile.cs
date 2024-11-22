using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.ProductId, expression => expression.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.Code, expression => expression.MapFrom(src => src.Code))
            .ForMember(dest => dest.Notify, expression => expression.MapFrom(src => src.Notify))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Name))
            .ForMember(dest => dest.IncomingPrice, expression => expression.MapFrom(src => src.IncomingPrice))
            .ForMember(dest => dest.SellPrice, expression => expression.MapFrom(src => src.SellPrice))
            .ForMember(dest => dest.LowExistence, expression => expression.MapFrom(src => src.LowExistence));

        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.ProductId, expression => expression.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.Code, expression => expression.MapFrom(src => src.Code))
            .ForMember(dest => dest.Notify, expression => expression.MapFrom(src => src.Notify))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Name))
            .ForMember(dest => dest.IncomingPrice, expression => expression.MapFrom(src => src.IncomingPrice))
            .ForMember(dest => dest.SellPrice, expression => expression.MapFrom(src => src.SellPrice))
            .ForMember(dest => dest.LowExistence, expression => expression.MapFrom(src => src.LowExistence));
        CreateMap<Product, ProductWithoutIDDTO>()
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.Notify, expression => expression.MapFrom(src => src.Notify))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Name))
            .ForMember(dest => dest.IncomingPrice, expression => expression.MapFrom(src => src.IncomingPrice))
            .ForMember(dest => dest.SellPrice, expression => expression.MapFrom(src => src.SellPrice))
            .ForMember(dest => dest.LowExistence, expression => expression.MapFrom(src => src.LowExistence));
        CreateMap<(ProductWithoutIDDTO, Guid, string), Product>()
            .ForMember(dest => dest.ProductId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.Item1.CompanyId))
            .ForMember(dest => dest.Code, expression => expression.MapFrom(src => src.Item3))
            .ForMember(dest => dest.Notify, expression => expression.MapFrom(src => src.Item1.Notify))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.IncomingPrice, expression => expression.MapFrom(src => src.Item1.IncomingPrice))
            .ForMember(dest => dest.SellPrice, expression => expression.MapFrom(src => src.Item1.SellPrice))
            .ForMember(dest => dest.LowExistence, expression => expression.MapFrom(src => src.Item1.LowExistence));

    }
}
