using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class ProductCategoriesProfile : Profile
{
    public ProductCategoriesProfile()
    {
        CreateMap<ProductCategoriesDTO, ProductCategories>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
        CreateMap<ProductCategories, ProductCategoriesDTO>()
            .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
    }
}