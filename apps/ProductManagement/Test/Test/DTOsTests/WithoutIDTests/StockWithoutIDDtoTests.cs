using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIDTests;

[TestFixture]
public class StockWithoutIddtoTests
{
    private StockWithoutIDDTO _stockWithoutIdDto;

    [SetUp]
    public void SetUp()
    {
        _stockWithoutIdDto = new StockWithoutIDDTO();
    }

    [Test]
    public void Code_ShouldBeOfTypeInt()
    {
        // Arrange
        _stockWithoutIdDto.Code = 54321;

        // Act
        var result = _stockWithoutIdDto.Code;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetCode()
    {
        // Arrange
        var code = 54321;
        _stockWithoutIdDto.Code = code;

        // Act
        var result = _stockWithoutIdDto.Code;

        // Assert
        Assert.That(result, Is.EqualTo(code));
    }

    [Test]
    public void CanSetCode()
    {
        // Arrange
        var code = 54321;

        // Act
        _stockWithoutIdDto.Code = code;

        // Assert
        Assert.That(_stockWithoutIdDto.Code, Is.EqualTo(code));
    }

    [Test]
    public void Quantity_ShouldBeOfTypeInt()
    {
        // Arrange
        _stockWithoutIdDto.Quantity = 100;

        // Act
        var result = _stockWithoutIdDto.Quantity;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetQuantity()
    {
        // Arrange
        var quantity = 100;
        _stockWithoutIdDto.Quantity = quantity;

        // Act
        var result = _stockWithoutIdDto.Quantity;

        // Assert
        Assert.That(result, Is.EqualTo(quantity));
    }

    [Test]
    public void CanSetQuantity()
    {
        // Arrange
        var quantity = 100;

        // Act
        _stockWithoutIdDto.Quantity = quantity;

        // Assert
        Assert.That(_stockWithoutIdDto.Quantity, Is.EqualTo(quantity));
    }

    [Test]
    public void ProductId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _stockWithoutIdDto.ProductId = Guid.NewGuid();

        // Act
        var result = _stockWithoutIdDto.ProductId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _stockWithoutIdDto.ProductId = productId;

        // Act
        var result = _stockWithoutIdDto.ProductId;

        // Assert
        Assert.That(result, Is.EqualTo(productId));
    }

    [Test]
    public void CanSetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        _stockWithoutIdDto.ProductId = productId;

        // Assert
        Assert.That(_stockWithoutIdDto.ProductId, Is.EqualTo(productId));
    }

    [Test]
    public void SubsidiaryId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _stockWithoutIdDto.SubsidiaryId = Guid.NewGuid();

        // Act
        var result = _stockWithoutIdDto.SubsidiaryId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetSubsidiaryId()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        _stockWithoutIdDto.SubsidiaryId = subsidiaryId;

        // Act
        var result = _stockWithoutIdDto.SubsidiaryId;

        // Assert
        Assert.That(result, Is.EqualTo(subsidiaryId));
    }

    [Test]
    public void CanSetSubsidiaryId()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();

        // Act
        _stockWithoutIdDto.SubsidiaryId = subsidiaryId;

        // Assert
        Assert.That(_stockWithoutIdDto.SubsidiaryId, Is.EqualTo(subsidiaryId));
    }
}
