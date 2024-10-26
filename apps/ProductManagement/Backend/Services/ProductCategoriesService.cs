using AutoMapper;
using Backend.DTOs.WithID;
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

    public async Task<List<ProductCategoriesDTO>> GetProductCategoriesByProductId(Guid productId)
    {
        return _productCategoriesDao.GetProductCategoriesByProductId(productId).Select(productCategory => _mapper.Map<ProductCategoriesDTO>(productCategory)).ToList();
    }

    public async Task<List<ProductCategoriesDTO>> GetProductCategoriesByCategoryId(Guid categoryId)
    {
        return _productCategoriesDao.GetProductCategoriesByCategoryId(categoryId).Select(productCategory => _mapper.Map<ProductCategoriesDTO>(productCategory)).ToList();
    }

    public async Task<ProductCategoriesDTO> GetProductCategoryByBothIds(ProductCategoriesDTO productCategory)
    {
        return _mapper.Map<ProductCategoriesDTO>(_productCategoriesDao.Read(productCategory.ProductId, productCategory.CategoryId));
    }

    public async Task<ProductCategoriesDTO> CreateProductCategory(ProductCategoriesDTO productCategory)
    {
        _productCategoriesDao.Create(_mapper.Map<ProductCategories>(productCategory));
        return _mapper.Map<ProductCategoriesDTO>(_productCategoriesDao.Read(productCategory.ProductId, productCategory.CategoryId));
    }

    public async Task<bool> DeleteProductCategory(ProductCategoriesDTO productCategory)
    {
        return _productCategoriesDao.Delete(productCategory.ProductId, productCategory.CategoryId);
    }
}