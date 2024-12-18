using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class ProductCategoriesService : IProductCategoriesService
{
    private readonly IProductCategoriesDAO _productCategoriesDao;
    private readonly IMapper _mapper;

    public ProductCategoriesService(IMapper mapper, IProductCategoriesDAO productCategoriesDao)
    {
        _productCategoriesDao = productCategoriesDao;
        _mapper = mapper;
    }

    public List<ProductCategoriesDTO> GetProductCategoriesByProductId(Guid productId)
    {
        return _productCategoriesDao.GetProductCategoriesByProductId(productId).Select(productCategory => _mapper.Map<ProductCategoriesDTO>(productCategory)).ToList();
    }

    public List<ProductCategoriesDTO> GetProductCategoriesByCategoryId(Guid categoryId)
    {
        return _productCategoriesDao.GetProductCategoriesByCategoryId(categoryId).Select(productCategory => _mapper.Map<ProductCategoriesDTO>(productCategory)).ToList();
    }

    public ProductCategoriesDTO GetProductCategoryByBothIds(ProductCategoriesDTO productCategory)
    {
        return _mapper.Map<ProductCategoriesDTO>(_productCategoriesDao.Read(productCategory.ProductId, productCategory.CategoryId));
    }

    public ProductCategoriesDTO CreateProductCategory(ProductCategoriesDTO productCategory)
    {
        _productCategoriesDao.Create(_mapper.Map<ProductCategories>(productCategory));
        return _mapper.Map<ProductCategoriesDTO>(_productCategoriesDao.Read(productCategory.ProductId, productCategory.CategoryId));
    }

    public bool DeleteProductCategory(ProductCategoriesDTO productCategory)
    {
        return _productCategoriesDao.Delete(productCategory.ProductId, productCategory.CategoryId);
    }

    public List<ProductCategoriesDTO> CreateProductCategories(ProductCategoryListPostDTO productCategoryList)
    {
        List<ProductCategoriesDTO> productCategories = new List<ProductCategoriesDTO>();
        foreach (Guid categoryId in productCategoryList.CategoryIds)
        {
            _productCategoriesDao.Create(new ProductCategories()
            {
                CategoryId = categoryId,
                ProductId = productCategoryList.ProductId
            });
            var newProductCategory = _productCategoriesDao.Read(productCategoryList.ProductId, categoryId);
            if (newProductCategory != null)
            {
                productCategories.Add(_mapper.Map<ProductCategoriesDTO>(newProductCategory));    
            }
            
        }
        return productCategories;
    }

    public List<ProductCategoriesDTO> UpdateProductCategories(ProductCategoryListPostDTO productCategoryListPost)
    {
        foreach (ProductCategories productCategory in _productCategoriesDao.GetProductCategoriesByProductId(productCategoryListPost.ProductId))
        {
            _productCategoriesDao.Delete(productCategory.ProductId, productCategory.CategoryId);
        }
        List<ProductCategoriesDTO> updatedProductCategories = new List<ProductCategoriesDTO>();
        foreach (Guid category in productCategoryListPost.CategoryIds)
        {
            _productCategoriesDao.Create(new ProductCategories()
            {
                CategoryId = category,
                ProductId = productCategoryListPost.ProductId
            });
            updatedProductCategories.Add(_mapper.Map<ProductCategoriesDTO>(_productCategoriesDao.Read(productCategoryListPost.ProductId, category)));
        }

        return updatedProductCategories;
    }
}
