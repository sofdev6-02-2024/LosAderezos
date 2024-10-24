using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIDTests;

[TestFixture]
public class CompanyWithoutIddtoTests
{
    private CompanyWithoutIDDTO _companyWithoutIdDto;

    [SetUp]
    public void SetUp()
    {
        _companyWithoutIdDto = new CompanyWithoutIDDTO();
    }

    [Test]
    public void Name_ShouldBeOfTypeString()
    {
        // Arrange
        _companyWithoutIdDto.Name = "TechCorp";

        // Act
        var result = _companyWithoutIdDto.Name;

        // Assert
        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void CanGetName()
    {
        // Arrange
        var name = "TechCorp";
        _companyWithoutIdDto.Name = name;

        // Act
        var result = _companyWithoutIdDto.Name;

        // Assert
        Assert.That(result, Is.EqualTo(name));
    }

    [Test]
    public void CanSetName()
    {
        // Arrange
        var name = "TechCorp";

        // Act
        _companyWithoutIdDto.Name = name;

        // Assert
        Assert.That(_companyWithoutIdDto.Name, Is.EqualTo(name));
    }

    [Test]
    public void UserId_ShouldBeOfTypeGuid()
    {
        // Arrange
        _companyWithoutIdDto.UserId = Guid.NewGuid();

        // Act
        var result = _companyWithoutIdDto.UserId;

        // Assert
        Assert.IsInstanceOf<Guid>(result);
    }

    [Test]
    public void CanGetUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();
        _companyWithoutIdDto.UserId = userId;

        // Act
        var result = _companyWithoutIdDto.UserId;

        // Assert
        Assert.That(result, Is.EqualTo(userId));
    }

    [Test]
    public void CanSetUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        _companyWithoutIdDto.UserId = userId;

        // Assert
        Assert.That(_companyWithoutIdDto.UserId, Is.EqualTo(userId));
    }

    [Test]
    public void Name_ShouldNotBeNullOrEmpty()
    {
        // Arrange
        _companyWithoutIdDto.Name = "TechCorp";

        // Act & Assert
        Assert.IsFalse(string.IsNullOrEmpty(_companyWithoutIdDto.Name));
    }
}
