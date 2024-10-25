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
        CreateMap<ProductWithoutIDDTO, Product>()
            .ForMember(dest => dest.ProductId,
                opt => opt.MapFrom(src => Guid.NewGuid()));
    }
}
