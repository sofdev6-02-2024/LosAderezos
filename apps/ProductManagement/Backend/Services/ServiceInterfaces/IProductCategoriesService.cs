using Backend.DTOs.WithID;

namespace Backend.Services.ServiceInterfaces;

public interface IProductCategoriesService
{
    public List<ProductCategoriesDTO> GetProductCategoriesByProductId(Guid productId);
    public List<ProductCategoriesDTO> GetProductCategoriesByCategoryId(Guid categoryId);
    public ProductCategoriesDTO GetProductCategoryByBothIds(ProductCategoriesDTO productCategory);
    public ProductCategoriesDTO CreateProductCategory(ProductCategoriesDTO productCategory);
    public bool DeleteProductCategory(ProductCategoriesDTO productCategory);
    
    
}
