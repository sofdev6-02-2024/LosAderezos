using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class SubsidiaryDtoTests
{
    private SubsidiaryDTO _subsidiaryDto;

    [SetUp]
    public void SetUp()
    {
        _subsidiaryDto = new SubsidiaryDTO();
    }

    [Test]
    public void SubsidiaryId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _subsidiaryDto.SubsidiaryId = Guid.NewGuid();

        // Act
        var result = _subsidiaryDto.SubsidiaryId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetSubsidiaryId()
    {
        // Arrange
        var id = Guid.NewGuid();
        _subsidiaryDto.SubsidiaryId = id;

        // Act
        var result = _subsidiaryDto.SubsidiaryId;

        // Assert
        Assert.That(result, Is.EqualTo(id));
    }

    [Test]
    public void CanSetSubsidiaryId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        _subsidiaryDto.SubsidiaryId = id;

        // Assert
        Assert.That(_subsidiaryDto.SubsidiaryId, Is.EqualTo(id));
    }

    [Test]
    public void Latitude_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _subsidiaryDto.Latitude = 40.7128m;

        // Act
        var result = _subsidiaryDto.Latitude;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetLatitude()
    {
        // Arrange
        var latitude = 40.7128m;
        _subsidiaryDto.Latitude = latitude;

        // Act
        var result = _subsidiaryDto.Latitude;

        // Assert
        Assert.That(result, Is.EqualTo(latitude));
    }

    [Test]
    public void CanSetLatitude()
    {
        // Arrange
        var latitude = 40.7128m;

        // Act
        _subsidiaryDto.Latitude = latitude;

        // Assert
        Assert.That(_subsidiaryDto.Latitude, Is.EqualTo(latitude));
    }

    [Test]
    public void Longitude_ShouldBeOfTypeDecimal()
    {
        // Arrange
        _subsidiaryDto.Longitude = -74.0060m;

        // Act
        var result = _subsidiaryDto.Longitude;

        // Assert
        Assert.IsInstanceOf<decimal>(result);
    }

    [Test]
    public void CanGetLongitude()
    {
        // Arrange
        var longitude = -74.0060m;
        _subsidiaryDto.Longitude = longitude;

        // Act
        var result = _subsidiaryDto.Longitude;

        // Assert
        Assert.That(result, Is.EqualTo(longitude));
    }

    [Test]
    public void CanSetLongitude()
    {
        // Arrange
        var longitude = -74.0060m;

        // Act
        _subsidiaryDto.Longitude = longitude;

        // Assert
        Assert.That(_subsidiaryDto.Longitude, Is.EqualTo(longitude));
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _subsidiaryDto.Name = "Main Office";

        // Act
        var result = _subsidiaryDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "Main Office";
        _subsidiaryDto.Name = name;

        // Act
        var result = _subsidiaryDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "Main Office";

        // Act
        _subsidiaryDto.Name = name;

        // Assert
        Assert.That(_subsidiaryDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void Type_ShouldBeOfTypeString()
    {
        // Arrange
        _subsidiaryDto.Type = "Warehouse";

        // Act
        var result = _subsidiaryDto.Type;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetType()
    {
        // Arrange
        var type = "Warehouse";
        _subsidiaryDto.Type = type;

        // Act
        var result = _subsidiaryDto.Type;

        // Assert
        Assert.That(result, Is.EqualTo(type));
    }

    [Test]
    public void CanSetType()
    {
        // Arrange
        var type = "Warehouse";

        // Act
        _subsidiaryDto.Type = type;

        // Assert
        Assert.That(_subsidiaryDto.Type, Is.EqualTo(type));
    }

    [Test]
    public void CompanyId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _subsidiaryDto.CompanyId = Guid.NewGuid();

        // Act
        var result = _subsidiaryDto.CompanyId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();
        _subsidiaryDto.CompanyId = companyId;

        // Act
        var result = _subsidiaryDto.CompanyId;

        // Assert
        Assert.That(result, Is.EqualTo(companyId));
    }

    [Test]
    public void CanSetCompanyId()
    {
        // Arrange
        var companyId = Guid.NewGuid();

        // Act
        _subsidiaryDto.CompanyId = companyId;

        // Assert
        Assert.That(_subsidiaryDto.CompanyId, Is.EqualTo(companyId));
    }
}
