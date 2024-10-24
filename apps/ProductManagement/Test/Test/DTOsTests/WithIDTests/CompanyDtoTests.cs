using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

[TestFixture]
public class CompanyDtoTests
{
    private CompanyDTO _companyDto;

    [SetUp]
    public void SetUp()
    {
        _companyDto = new CompanyDTO();
    }

    [Test]
    public void CompanyId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _companyDto.CompanyId = Guid.NewGuid();

        // Act
        var result = _companyDto.CompanyId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetCompanyId()
    {
        // Arrange
        var id = Guid.NewGuid();
        _companyDto.CompanyId = id;

        // Act
        var result = _companyDto.CompanyId;

        // Assert
        Assert.That(result, Is.EqualTo(id));
    }

    [Test]
    public void CanSetCompanyId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        _companyDto.CompanyId = id;

        // Assert
        Assert.That(_companyDto.CompanyId, Is.EqualTo(id));
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _companyDto.Name = "TechCorp";

        // Act
        var result = _companyDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "TechCorp";
        _companyDto.Name = name;

        // Act
        var result = _companyDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "TechCorp";

        // Act
        _companyDto.Name = name;

        // Assert
        Assert.That(_companyDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void UserId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _companyDto.UserId = Guid.NewGuid();

        // Act
        var result = _companyDto.UserId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();
        _companyDto.UserId = userId;

        // Act
        var result = _companyDto.UserId;

        // Assert
        Assert.That(result, Is.EqualTo(userId));
    }

    [Test]
    public void CanSetUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        _companyDto.UserId = userId;

        // Assert
        Assert.That(_companyDto.UserId, Is.EqualTo(userId));
    }

    [Test]
    public void Name_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        _companyDto.Name = "TechCorp";

        // Act & Assert
        Assert.IsFalse(string.IsNullOrEmpty(_companyDto.Name));
    }
}
