using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class ProductDtoTests
{
    private ProductDTO _productDto;

    [SetUp]
    public void SetUp()
    {
        _productDto = new ProductDTO();
    }

    [Test]
    public void ProductId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _productDto.ProductId = Guid.NewGuid();

        // Act
        var result = _productDto.ProductId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetProductId()
    {
        // Arrange
        var id = Guid.NewGuid();
        _productDto.ProductId = id;

        // Act
        var result = _productDto.ProductId;

        // Assert
        Assert.That(result, Is.EqualTo(id));
    }

    [Test]
    public void CanSetProductId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        _productDto.ProductId = id;

        // Assert
        Assert.That(_productDto.ProductId, Is.EqualTo(id));
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _productDto.Name = "Laptop";

        // Act
        var result = _productDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Laptop";
        _productDto.Name = name;

        // Act
        var result = _productDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Laptop";

        // Act
        _productDto.Name = name;

        // Assert
        Assert.That(_productDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void IncomingPrice_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _productDto.IncomingPrice = 1000.50m;

        // Act
        var result = _productDto.IncomingPrice;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetIncomingPrice()
    {
        // Arrange
        var price = 1000.50m;
        _productDto.IncomingPrice = price;

        // Act
        var result = _productDto.IncomingPrice;

        // Assert
        Assert.That(result, Is.EqualTo(price));
    }

    [Test]
    public void CanSetIncomingPrice()
    {
        // Arrange
        var price = 1000.50m;

        // Act
        _productDto.IncomingPrice = price;

        // Assert
        Assert.That(_productDto.IncomingPrice, Is.EqualTo(price));
    }

    [Test]
    public void Code_ShouldBeOfTypeInt()
    {
        // Arrange
        _productDto.Code = 12345;

        // Act
        var result = _productDto.Code;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetCode()
    {
        // Arrange
        var code = 12345;
        _productDto.Code = code;

        // Act
        var result = _productDto.Code;

        // Assert
        Assert.That(result, Is.EqualTo(code));
    }

    [Test]
    public void CanSetCode()
    {
        // Arrange
        var code = 12345;

        // Act
        _productDto.Code = code;

        // Assert
        Assert.That(_productDto.Code, Is.EqualTo(code));
    }

    [Test]
    public void SellPrice_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _productDto.SellPrice = 1500.75m;

        // Act
        var result = _productDto.SellPrice;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetSellPrice()
    {
        // Arrange
        var sellPrice = 1500.75m;
        _productDto.SellPrice = sellPrice;

        // Act
        var result = _productDto.SellPrice;

        // Assert
        Assert.That(result, Is.EqualTo(sellPrice));
    }

    [Test]
    public void CanSetSellPrice()
    {
        // Arrange
        var sellPrice = 1500.75m;

        // Act
        _productDto.SellPrice = sellPrice;

        // Assert
        Assert.That(_productDto.SellPrice, Is.EqualTo(sellPrice));
    }

    [Test]
    public void CompanyId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _productDto.CompanyId = Guid.NewGuid();

        // Act
        var result = _productDto.CompanyId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        _productDto.CompanyId = companyId;

        // Act
        var result = _productDto.CompanyId;

        // Assert
        Assert.That(result, Is.EqualTo(companyId));
    }

    [Test]
    public void CanSetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();

        // Act
        _productDto.CompanyId = companyId;

        // Assert
        Assert.That(_productDto.CompanyId, Is.EqualTo(companyId));
    }
}
