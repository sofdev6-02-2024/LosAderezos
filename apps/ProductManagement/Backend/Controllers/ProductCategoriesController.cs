using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoriesService _productCategoriesService;

    public ProductCategoriesController(IProductCategoriesService productCategoriesService)
    {
        _productCategoriesService = productCategoriesService;
    }

    [HttpGet("category/{categoryId}")]
    public ActionResult<List<ProductCategoriesDTO>> GetProductCategoriesByCategoryId(Guid categoryId)
    {
        var result = _productCategoriesService.GetProductCategoriesByCategoryId(categoryId);
        return Ok(result);
    }
    
    [HttpGet("product/{productId}")]
    public ActionResult<List<ProductCategoriesDTO>> GetProductCategoriesByProductId(Guid productId)
    {
        var result = _productCategoriesService.GetProductCategoriesByProductId(productId);
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<ProductCategoriesDTO> GetProductCategoryByBothIds(ProductCategoriesDTO productCategoriesDto)
    {
        var result = _productCategoriesService.GetProductCategoryByBothIds(productCategoriesDto);
        return Ok(result);
    }

    [HttpPost("List")]
    public ActionResult<List<ProductCategoriesDTO>> CreateListProductCategories(ProductCategoryListPostDTO productCategoryList)
    {
        var result = _productCategoriesService.CreateProductCategories(productCategoryList);
        return Ok(result);
    }
    
    [HttpPut]
    public ActionResult<List<ProductCategoriesDTO>> UpdateProductCategories(ProductCategoryListPostDTO productCategoryListPost)
    {
        var result = _productCategoriesService.UpdateProductCategories(productCategoryListPost);
        return Ok(result);
    }
    
    [HttpDelete]
    public ActionResult<bool> DeleteProductCategoryByBothIds(ProductCategoriesDTO productCategoriesDto)
    {
        var result = _productCategoriesService.DeleteProductCategory(productCategoriesDto);
        return Ok(result);
    }
}
