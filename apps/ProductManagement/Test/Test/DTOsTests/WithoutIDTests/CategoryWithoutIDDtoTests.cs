using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIDTests;

[TestFixture]
public class CategoryWithoutIddtoTests
{
    private CategoryWithoutIDDTO _categoryWithoutIddto;

    [SetUp]
    public void SetUp()
    {
        _categoryWithoutIddto = new CategoryWithoutIDDTO();
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _categoryWithoutIddto.Name = "Electronics";

        // Act
        var result = _categoryWithoutIddto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Electronics";
        _categoryWithoutIddto.Name = name;

        // Act
        var result = _categoryWithoutIddto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Electronics";

        // Act
        _categoryWithoutIddto.Name = name;

        // Assert
        Assert.That(_categoryWithoutIddto.Name, Is.EqualTo(name));
    }

    [Test]
    public void Name_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        _categoryWithoutIddto.Name = "Electronics";

        // Act & Assert
        Assert.IsFalse(string.IsNullOrEmpty(_categoryWithoutIddto.Name));
    }
}
