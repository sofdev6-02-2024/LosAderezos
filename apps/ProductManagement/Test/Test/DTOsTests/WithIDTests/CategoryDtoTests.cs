using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class CategoryDtoTests
{
    private CategoryDTO _categoryDto;

    [SetUp]
    public void SetUp()
    {
        _categoryDto = new CategoryDTO();
    }
    
    [Test]
    public void CategoryId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _categoryDto.CategoryId = Guid.NewGuid();

        // Act
        var result = _categoryDto.CategoryId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCategoryId()
    {
        // Arrange
        var id = Guid.NewGuid();
        _categoryDto.CategoryId = id;

        // Act
        var result = _categoryDto.CategoryId;

        // Assert
        Assert.That(result, Is.EqualTo(id));
    }

    [Test]
    public void CanSetCategoryId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        _categoryDto.CategoryId = id;

        // Assert
        Assert.That(_categoryDto.CategoryId, Is.EqualTo(id));
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _categoryDto.Name = "Electronics";

        // Act
        var result = _categoryDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Electronics";
        _categoryDto.Name = name;

        // Act
        var result = _categoryDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Electronics";

        // Act
        _categoryDto.Name = name;

        // Assert
        Assert.That(_categoryDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void Name_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        _categoryDto.Name = "Electronics";

        // Act & Assert
        Assert.IsFalse(string.IsNullOrEmpty(_categoryDto.Name));
    }
}
