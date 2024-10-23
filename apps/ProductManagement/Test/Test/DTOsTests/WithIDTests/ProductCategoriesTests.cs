using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class ProductCategoriesDtoTests
{
    private ProductCategoriesDTO _productCategoriesDto;

    [SetUp]
    public void SetUp()
    {
        _productCategoriesDto = new ProductCategoriesDTO();
    }

    [Test]
    public void ProductId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _productCategoriesDto.ProductId = Guid.NewGuid();

        // Act
        var result = _productCategoriesDto.ProductId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _productCategoriesDto.ProductId = productId;

        // Act
        var result = _productCategoriesDto.ProductId;

        // Assert
        Assert.That(result, Is.EqualTo(productId));
    }

    [Test]
    public void CanSetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        _productCategoriesDto.ProductId = productId;

        // Assert
        Assert.That(_productCategoriesDto.ProductId, Is.EqualTo(productId));
    }

    [Test]
    public void CategoryId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _productCategoriesDto.CategoryId = Guid.NewGuid();

        // Act
        var result = _productCategoriesDto.CategoryId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCategoryId()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        _productCategoriesDto.CategoryId = categoryId;

        // Act
        var result = _productCategoriesDto.CategoryId;

        // Assert
        Assert.That(result, Is.EqualTo(categoryId));
    }

    [Test]
    public void CanSetCategoryId()
    {
        // Arrange
        var categoryId = Guid.NewGuid();

        // Act
        _productCategoriesDto.CategoryId = categoryId;

        // Assert
        Assert.That(_productCategoriesDto.CategoryId, Is.EqualTo(categoryId));
    }

    [Test]
    public void ShouldHaveUniqueProductAndCategoryCombination()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var categoryId = Guid.NewGuid();

        // Act
        _productCategoriesDto.ProductId = productId;
        _productCategoriesDto.CategoryId = categoryId;

        // Assert
        Assert.That(_productCategoriesDto.ProductId, Is.EqualTo(productId));
        Assert.That(_productCategoriesDto.CategoryId, Is.EqualTo(categoryId));
    }
}
