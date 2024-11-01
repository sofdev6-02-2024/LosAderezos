using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetProducts()
    {
        var result = await _productService.GetProducts();
        return Ok(result);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(Guid productId)
    {
        var result = await _productService.GetProductById(productId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(ProductWithoutIDDTO product)
    {
        var result = await _productService.CreateProduct(product);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> UpdateProduct(ProductDTO product)
    {
        var result = await _productService.UpdateProduct(product);
        return Ok(result);
    }
}
