using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryDAO _categoryDao;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, ICategoryDAO categoryDao)
    {
        _mapper = mapper;
        _categoryDao = categoryDao;
    }

    public List<CategoryDTO> GetCategories()
    {
        return _categoryDao.ReadAll().Select(_mapper.Map<CategoryDTO>).ToList();
    }

    public CategoryDTO? GetCategoryById(Guid id)
    {
        return _mapper.Map<CategoryDTO>(_categoryDao.Read(id));
    }

    public CategoryDTO? CreateCategory(CategoryWithoutIDDTO category)
    {
        Guid guid = Guid.NewGuid();
        _categoryDao.Create(_mapper.Map<Category>((category, guid)));
        return _mapper.Map<CategoryDTO>(_categoryDao.Read(guid));
    }

    public CategoryDTO? UpdateCategory(CategoryDTO category)
    {
        _categoryDao.Update(_mapper.Map<Category>(category));
        return _mapper.Map<CategoryDTO>(_categoryDao.Read(category.CategoryId));
    }
}
