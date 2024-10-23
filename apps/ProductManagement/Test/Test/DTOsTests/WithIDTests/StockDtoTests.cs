using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class StockDtoTests
{
    private StockDTO _stockDto;

    [SetUp]
    public void SetUp()
    {
        _stockDto = new StockDTO();
    }

    [Test]
    public void StockId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _stockDto.StockId = Guid.NewGuid();

        // Act
        var result = _stockDto.StockId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetStockId()
    {
        // Arrange
        var id = Guid.NewGuid();
        _stockDto.StockId = id;

        // Act
        var result = _stockDto.StockId;

        // Assert
        Assert.That(id, Is.EqualTo(result));
    }

    [Test]
    public void CanSetStockId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        _stockDto.StockId = id;

        // Assert
        Assert.That(_stockDto.StockId, Is.EqualTo(id));
    }

    [Test]
    public void Code_ShouldBeOfTypeInt()
    {
        // Arrange
        _stockDto.Code = 54321;

        // Act
        var result = _stockDto.Code;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetCode()
    {
        // Arrange
        var code = 54321;
        _stockDto.Code = code;

        // Act
        var result = _stockDto.Code;

        // Assert
        Assert.That(result, Is.EqualTo(code));
    }

    [Test]
    public void CanSetCode()
    {
        // Arrange
        var code = 54321;

        // Act
        _stockDto.Code = code;

        // Assert
        Assert.That(_stockDto.Code, Is.EqualTo(code));
    }

    [Test]
    public void Quantity_ShouldBeOfTypeInt()
    {
        // Arrange
        _stockDto.Quantity = 100;

        // Act
        var result = _stockDto.Quantity;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetQuantity()
    {
        // Arrange
        var quantity = 100;
        _stockDto.Quantity = quantity;

        // Act
        var result = _stockDto.Quantity;

        // Assert
        Assert.That(result, Is.EqualTo(quantity));
    }

    [Test]
    public void CanSetQuantity()
    {
        // Arrange
        var quantity = 100;

        // Act
        _stockDto.Quantity = quantity;

        // Assert
        Assert.That(_stockDto.Quantity, Is.EqualTo(quantity));
    }

    [Test]
    public void ProductId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _stockDto.ProductId = Guid.NewGuid();

        // Act
        var result = _stockDto.ProductId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();
        _stockDto.ProductId = productId;

        // Act
        var result = _stockDto.ProductId;

        // Assert
        Assert.That(result, Is.EqualTo(productId));
    }

    [Test]
    public void CanSetProductId()
    {
        // Arrange
        var productId = Guid.NewGuid();

        // Act
        _stockDto.ProductId = productId;

        // Assert
        Assert.That(_stockDto.ProductId, Is.EqualTo(productId));
    }

    [Test]
    public void SubsidiaryId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _stockDto.SubsidiaryId = Guid.NewGuid();

        // Act
        var result = _stockDto.SubsidiaryId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetSubsidiaryId()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        _stockDto.SubsidiaryId = subsidiaryId;

        // Act
        var result = _stockDto.SubsidiaryId;

        // Assert
        Assert.That(result, Is.EqualTo(subsidiaryId));
    }

    [Test]
    public void CanSetSubsidiaryId()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();

        // Act
        _stockDto.SubsidiaryId = subsidiaryId;

        // Assert
        Assert.That(_stockDto.SubsidiaryId, Is.EqualTo(subsidiaryId));
    }
}
