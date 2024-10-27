using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Mappers;
using DB;
using Backend.Services;
using Moq;

namespace Test.ServivcesTests;

[TestFixture]
public class CategoryServiceTests
{
    private Mock<ICategoryDAO> _categoryDaoMock;
    private Mock<IMapper> _mapperMock;
    private CategoryService _categoryService;

    [SetUp]
    public void SetUp()
    {
        _categoryDaoMock = new Mock<ICategoryDAO>();
        _mapperMock = new Mock<IMapper>();
        _categoryService = new CategoryService(_mapperMock.Object, _categoryDaoMock.Object);
    }

    [Test]
    public async Task GetCategories_ShouldReturnMappedCategories()
    {
        // Arrange
        var categories = new List<Category> { new Category { CategoryId = Guid.NewGuid(), Name = "Test" } };
        var categoryDtos = categories.Select(c => new CategoryDTO { CategoryId = c.CategoryId, Name = c.Name }).ToList();

        _categoryDaoMock.Setup(x => x.ReadAll()).Returns(categories);
        _mapperMock.Setup(m => m.Map<CategoryDTO>(It.IsAny<Category>())).Returns((Category source) => new CategoryDTO
        {
            CategoryId = source.CategoryId,
            Name = source.Name
        });

        // Act
        var result = await _categoryService.GetCategories();

        // Assert
        Assert.AreEqual(categoryDtos.Count, result.Count);
        Assert.AreEqual(categoryDtos.First().CategoryId, result.First().CategoryId);
    }

    [Test]
    public async Task GetCategoryById_ShouldReturnMappedCategory()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var category = new Category { CategoryId = categoryId, Name = "Test Category" };
        var categoryDto = new CategoryDTO { CategoryId = categoryId, Name = "Test Category" };

        _categoryDaoMock.Setup(x => x.Read(categoryId)).Returns(category);
        _mapperMock.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

        // Act
        var result = await _categoryService.GetCategoryById(categoryId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(categoryDto.CategoryId, result?.CategoryId);
    }

    [Test]
    public async Task CreateCategory_ShouldCreateAndReturnMappedCategory()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var categoryWithoutIdDto = new CategoryWithoutIDDTO { Name = "New Category" };
        var category = new Category { CategoryId = categoryId, Name = categoryWithoutIdDto.Name };
        var categoryDto = new CategoryDTO { CategoryId = categoryId, Name = categoryWithoutIdDto.Name };

        _mapperMock.Setup(mapper => mapper.Map<Category>(It.IsAny<(CategoryWithoutIDDTO, Guid)>())).Returns(category);
        _categoryDaoMock.Setup(x => x.Read(It.IsAny<Guid>())).Returns(category);
        _mapperMock.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

        // Act
        var result = await _categoryService.CreateCategory(categoryWithoutIdDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(categoryDto.CategoryId, result?.CategoryId);
        Assert.AreEqual(categoryDto.Name, result?.Name);
    }

    [Test]
    public async Task UpdateCategory_ShouldUpdateAndReturnMappedCategory()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var categoryDto = new CategoryDTO { CategoryId = categoryId, Name = "Updated Category" };
        var category = new Category { CategoryId = categoryId, Name = categoryDto.Name };

        _mapperMock.Setup(m => m.Map<Category>(categoryDto)).Returns(category);
        _categoryDaoMock.Setup(x => x.Update(category));
        _categoryDaoMock.Setup(x => x.Read(categoryId)).Returns(category);
        _mapperMock.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

        // Act
        var result = await _categoryService.UpdateCategory(categoryDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(categoryDto.CategoryId, result?.CategoryId);
        Assert.AreEqual(categoryDto.Name, result?.Name);
    }
}
