using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface ICategoryService
{
    public Task<List<CategoryDTO>> GetCategories();
    public Task<CategoryDTO?> GetCategoryById(Guid id);
    public Task<CategoryDTO?> CreateCategory(CategoryWithoutIDDTO category);
    public Task<CategoryDTO?> UpdateCategory(CategoryDTO category);    
}
