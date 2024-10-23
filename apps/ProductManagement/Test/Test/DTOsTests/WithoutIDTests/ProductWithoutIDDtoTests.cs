using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithoutIDTests;

[TestFixture]
public class ProductWithoutIddtoTests
{
    private ProductWithoutIDDTO _productWithoutIDDTO;

    [SetUp]
    public void SetUp()
    {
        _productWithoutIDDTO = new ProductWithoutIDDTO();
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _productWithoutIDDTO.Name = "Laptop";

        // Act
        var result = _productWithoutIDDTO.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Laptop";
        _productWithoutIDDTO.Name = name;

        // Act
        var result = _productWithoutIDDTO.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Laptop";

        // Act
        _productWithoutIDDTO.Name = name;

        // Assert
        Assert.That(_productWithoutIDDTO.Name, Is.EqualTo(name));
    }

    [Test]
    public void IncomingPrice_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _productWithoutIDDTO.IncomingPrice = 1000.50m;

        // Act
        var result = _productWithoutIDDTO.IncomingPrice;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetIncomingPrice()
    {
        // Arrange
        var price = 1000.50m;
        _productWithoutIDDTO.IncomingPrice = price;

        // Act
        var result = _productWithoutIDDTO.IncomingPrice;

        // Assert
        Assert.That(result, Is.EqualTo(price));
    }

    [Test]
    public void CanSetIncomingPrice()
    {
        // Arrange
        var price = 1000.50m;

        // Act
        _productWithoutIDDTO.IncomingPrice = price;

        // Assert
        Assert.That(_productWithoutIDDTO.IncomingPrice, Is.EqualTo(price));
    }

    [Test]
    public void Code_ShouldBeOfTypeInt()
    {
        // Arrange
        _productWithoutIDDTO.Code = 12345;

        // Act
        var result = _productWithoutIDDTO.Code;

        // Assert
        Assert.IsInstanceOf<int>(result);
    }

    [Test]
    public void CanGetCode()
    {
        // Arrange
        var code = 12345;
        _productWithoutIDDTO.Code = code;

        // Act
        var result = _productWithoutIDDTO.Code;

        // Assert
        Assert.That(result, Is.EqualTo(code));
    }

    [Test]
    public void CanSetCode()
    {
        // Arrange
        var code = 12345;

        // Act
        _productWithoutIDDTO.Code = code;

        // Assert
        Assert.That(_productWithoutIDDTO.Code, Is.EqualTo(code));
    }

    [Test]
    public void SellPrice_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _productWithoutIDDTO.SellPrice = 1500.75m;

        // Act
        var result = _productWithoutIDDTO.SellPrice;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetSellPrice()
    {
        // Arrange
        var sellPrice = 1500.75m;
        _productWithoutIDDTO.SellPrice = sellPrice;

        // Act
        var result = _productWithoutIDDTO.SellPrice;

        // Assert
        Assert.That(result, Is.EqualTo(sellPrice));
    }

    [Test]
    public void CanSetSellPrice()
    {
        // Arrange
        var sellPrice = 1500.75m;

        // Act
        _productWithoutIDDTO.SellPrice = sellPrice;

        // Assert
        Assert.That(_productWithoutIDDTO.SellPrice, Is.EqualTo(sellPrice));
    }

    [Test]
    public void CompanyId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _productWithoutIDDTO.CompanyId = Guid.NewGuid();

        // Act
        var result = _productWithoutIDDTO.CompanyId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        _productWithoutIDDTO.CompanyId = companyId;

        // Act
        var result = _productWithoutIDDTO.CompanyId;

        // Assert
        Assert.That(result, Is.EqualTo(companyId));
    }

    [Test]
    public void CanSetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();

        // Act
        _productWithoutIDDTO.CompanyId = companyId;

        // Assert
        Assert.That(_productWithoutIDDTO.CompanyId, Is.EqualTo(companyId));
    }
}
