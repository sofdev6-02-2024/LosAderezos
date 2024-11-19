using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public ActionResult<List<CategoryDTO>> GetAllCategories()
    {
        var result = _categoryService.GetCategories();
        return Ok(result);
    }

    [HttpGet("{categoryId}")]
    public ActionResult<CategoryDTO> GetCategoryById(Guid categoryId)
    {
        var result = _categoryService.GetCategoryById(categoryId);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<CategoryDTO> CreateCategory(CategoryWithoutIDDTO category)
    {
        var result = _categoryService.CreateCategory(category);
        return Ok(result);
    }

    [HttpPut]
    public ActionResult<CategoryDTO> UpdateCategory(CategoryDTO category)
    {
        var result = _categoryService.UpdateCategory(category);
        return Ok(result);
    }
}
