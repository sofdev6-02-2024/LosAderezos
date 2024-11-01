using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class CategoryProfile: Profile
{
    protected CategoryProfile()
    {
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<(CategoryWithoutIDDTO, Guid), Category>()
            .ForMember(dest => dest.CategoryId, expression => expression.MapFrom(src => src.Item2));
        CreateMap<Category, CategoryWithoutIDDTO>();

    }
}
