using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIdTests;

[TestFixture]
public class CreateTokenDTOTests
{
    [Test]
    public void CreateTokenDTO_Should_SetAndGetEmailProperty()
    {
        // Arrange
        var dto = new CreateTokenDTO();
        var email = "test@example.com";
        
        // Act
        dto.Email = email;

        // Assert
        Assert.That(dto.Email, Is.EqualTo(email));
    }

    [Test]
    public void CreateTokenDTO_Should_SetAndGetTokenProperty()
    {
        // Arrange
        var dto = new CreateTokenDTO();
        var token = "12345";

        // Act
        dto.Token = token;

        // Assert
        Assert.That(dto.Token, Is.EqualTo(token));
    }

    [Test]
    public void CreateTokenDTO_Should_HaveDefaultValues()
    {
        // Arrange
        var dto = new CreateTokenDTO();

        // Assert
        Assert.IsNull(dto.Email);
        Assert.IsNull(dto.Token);
    }
}
