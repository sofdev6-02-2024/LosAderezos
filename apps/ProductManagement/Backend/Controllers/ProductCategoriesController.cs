using Backend.DTOs.WithID;
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

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<List<ProductCategoriesDTO>>> GetProductCategoriesByCategoryId(Guid categoryId)
    {
        var result = _productCategoriesService.GetProductCategoriesByCategoryId(categoryId);
        return Ok(result);
    }
    
    [HttpGet("{productId}")]
    public async Task<ActionResult<List<ProductCategoriesDTO>>> GetProductCategoriesByProductId(Guid productId)
    {
        var result = _productCategoriesService.GetProductCategoriesByProductId(productId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductCategoriesDTO>> GetProductCategoryByBothIds(ProductCategoriesDTO productCategoriesDto)
    {
        var result = _productCategoriesService.GetProductCategoryByBothIds(productCategoriesDto);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteProductCategoryByBothIds(ProductCategoriesDTO productCategoriesDto)
    {
        var result = _productCategoriesService.DeleteProductCategory(productCategoriesDto);
        return Ok(result);
    }
}
