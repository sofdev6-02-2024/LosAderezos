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
    public ActionResult<List<ProductDTO>> GetProducts()
    {
        var result = _productService.GetProducts();
        return Ok(result);
    }

    [HttpGet("{productId}")]
    public ActionResult<ProductDTO> GetProductById(Guid productId)
    {
        var result = _productService.GetProductById(productId);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<ProductDTO> CreateProduct(ProductWithoutIDDTO product)
    {
        var result = _productService.CreateProduct(product);
        return Ok(result);
    }

    [HttpPut("{productId}")]
    public ActionResult<ProductDTO> UpdateProduct(Guid productId, ProductWithoutIDDTO product)
    {
        var result = _productService.UpdateProduct(productId, product);
        return Ok(result);
    }
}
