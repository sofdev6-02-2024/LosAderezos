using Backend.DTOs.WithID;

namespace Backend.Services.ServiceInterfaces;

public interface IProductCategoriesService
{
    public Task<List<ProductCategoriesDTO>> GetProductCategoriesByProductId(Guid productId);
    public Task<List<ProductCategoriesDTO>> GetProductCategoriesByCategoryId(Guid categoryId);
    public Task<ProductCategoriesDTO> GetProductCategoryByBothIds(ProductCategoriesDTO productCategory);
    public Task<ProductCategoriesDTO> CreateProductCategory(ProductCategoriesDTO productCategory);
    public Task<bool> DeleteProductCategory(ProductCategoriesDTO productCategory);
    
    
}
