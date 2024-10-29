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
        CreateMap< (ProductWithoutIDDTO, Guid), Product>()
            .ForMember(dest => dest.ProductId, expression => expression.MapFrom(src => src.Item2));
    }
}
