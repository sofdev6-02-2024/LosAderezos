using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductWithoutIDDTO>();
        CreateMap<(ProductWithoutIDDTO, Guid), Product>()
            .ForMember(dest => dest.ProductId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.Item1.CompanyId))
            .ForMember(dest => dest.Code, expression => expression.MapFrom(src => src.Item1.Code))
            .ForMember(dest => dest.Notify, expression => expression.MapFrom(src => src.Item1.Notify))
            .ForMember(dest => dest.Name, expression => expression.MapFrom(src => src.Item1.Name))
            .ForMember(dest => dest.IncomingPrice, expression => expression.MapFrom(src => src.Item1.IncomingPrice))
            .ForMember(dest => dest.SellPrice, expression => expression.MapFrom(src => src.Item1.SellPrice))
            .ForMember(dest => dest.LowExistence, expression => expression.MapFrom(src => src.Item1.LowExistence));

    }
}
