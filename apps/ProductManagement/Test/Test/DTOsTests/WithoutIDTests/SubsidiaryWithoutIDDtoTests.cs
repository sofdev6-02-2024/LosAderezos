using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIDTests;

[TestFixture]
public class SubsidiaryWithoutDtoTests
{
    private SubsidiaryWithoutDTO _subsidiaryWithoutDto;

    [SetUp]
    public void SetUp()
    {
        _subsidiaryWithoutDto = new SubsidiaryWithoutDTO();
    }

    [Test]
    public void Latitude_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _subsidiaryWithoutDto.Latitude = 40.7128m;

        // Act
        var result = _subsidiaryWithoutDto.Latitude;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetLatitude()
    {
        // Arrange
        var latitude = 40.7128m;
        _subsidiaryWithoutDto.Latitude = latitude;

        // Act
        var result = _subsidiaryWithoutDto.Latitude;

        // Assert
        Assert.That(result, Is.EqualTo(latitude));
    }

    [Test]
    public void CanSetLatitude()
    {
        // Arrange
        var latitude = 40.7128m;

        // Act
        _subsidiaryWithoutDto.Latitude = latitude;

        // Assert
        Assert.That(_subsidiaryWithoutDto.Latitude, Is.EqualTo(latitude));
    }

    [Test]
    public void Longitude_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _subsidiaryWithoutDto.Longitude = -74.0060m;

        // Act
        var result = _subsidiaryWithoutDto.Longitude;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetLongitude()
    {
        // Arrange
        var longitude = -74.0060m;
        _subsidiaryWithoutDto.Longitude = longitude;

        // Act
        var result = _subsidiaryWithoutDto.Longitude;

        // Assert
        Assert.That(result, Is.EqualTo(longitude));
    }

    [Test]
    public void CanSetLongitude()
    {
        // Arrange
        var longitude = -74.0060m;

        // Act
        _subsidiaryWithoutDto.Longitude = longitude;

        // Assert
        Assert.That(_subsidiaryWithoutDto.Longitude, Is.EqualTo(longitude));
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _subsidiaryWithoutDto.Name = "Main Office";

        // Act
        var result = _subsidiaryWithoutDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Main Office";
        _subsidiaryWithoutDto.Name = name;

        // Act
        var result = _subsidiaryWithoutDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Main Office";

        // Act
        _subsidiaryWithoutDto.Name = name;

        // Assert
        Assert.That(_subsidiaryWithoutDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void Type_ShouldBeOfTypeString()
    {
        // Arrange
        _subsidiaryWithoutDto.Type = "Warehouse";

        // Act
        var result = _subsidiaryWithoutDto.Type;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetType()
    {
        // Arrange
        var type = "Warehouse";
        _subsidiaryWithoutDto.Type = type;

        // Act
        var result = _subsidiaryWithoutDto.Type;

        // Assert
        Assert.That(result, Is.EqualTo(type));
    }

    [Test]
    public void CanSetType()
    {
        // Arrange
        var type = "Warehouse";

        // Act
        _subsidiaryWithoutDto.Type = type;

        // Assert
        Assert.That(_subsidiaryWithoutDto.Type, Is.EqualTo(type));
    }

    [Test]
    public void CompanyId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _subsidiaryWithoutDto.CompanyId = Guid.NewGuid();

        // Act
        var result = _subsidiaryWithoutDto.CompanyId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        _subsidiaryWithoutDto.CompanyId = companyId;

        // Act
        var result = _subsidiaryWithoutDto.CompanyId;

        // Assert
        Assert.That(result, Is.EqualTo(companyId));
    }

    [Test]
    public void CanSetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();

        // Act
        _subsidiaryWithoutDto.CompanyId = companyId;

        // Assert
        Assert.That(_subsidiaryWithoutDto.CompanyId, Is.EqualTo(companyId));
    }
}
