using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class CategoryProfile: Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDTO>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<CategoryDTO, Category>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<(CategoryWithoutIDDTO, Guid), Category>()
            .ForMember(dest => dest.CategoryId, expression => expression.MapFrom(src => src.Item2))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Item1.Name));
        CreateMap<Category, CategoryWithoutIDDTO>()
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

    }
}
