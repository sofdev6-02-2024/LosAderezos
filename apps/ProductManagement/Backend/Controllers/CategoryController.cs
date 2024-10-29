using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/productManagement/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
    {
        var result = await _categoryService.GetCategories();
        return Ok(result);
    }

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<CategoryDTO>> GetCategoryById(Guid categoryId)
    {
        var result = await _categoryService.GetCategoryById(categoryId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryWithoutIDDTO category)
    {
        var result = await _categoryService.CreateCategory(category);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<CategoryDTO>> UpdateCategory(CategoryDTO category)
    {
        var result = await _categoryService.UpdateCategory(category);
        return Ok(result);
    }
}
