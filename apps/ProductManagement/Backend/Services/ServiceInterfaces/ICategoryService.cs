using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface ICategoryService
{
    public List<CategoryDTO> GetCategories();
    public CategoryDTO? GetCategoryById(Guid id);
    public CategoryDTO? CreateCategory(CategoryWithoutIDDTO category);
    public CategoryDTO? UpdateCategory(CategoryDTO category);    
}
