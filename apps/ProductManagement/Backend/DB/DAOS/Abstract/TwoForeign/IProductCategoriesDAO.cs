using Backend.Entities;

namespace DB;

public interface IProductCategoriesDAO : ITwoForeignDAO<ProductCategories>
{
    List<ProductCategories> GetProductCategoriesByProductId(Guid productId);
    List<ProductCategories> GetProductCategoriesByCategoryId(Guid categoryId);
}
