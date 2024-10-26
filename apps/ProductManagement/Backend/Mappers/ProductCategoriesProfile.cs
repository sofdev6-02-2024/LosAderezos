using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class ProductCategoriesProfile : Profile
{
    protected ProductCategoriesProfile()
    {
        CreateMap<ProductCategoriesDTO, ProductCategories>();
        CreateMap<ProductCategories, ProductCategoriesDTO>();
    }
}