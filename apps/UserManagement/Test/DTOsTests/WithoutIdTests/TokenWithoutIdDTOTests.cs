using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIdTests;

[TestFixture]
public class TokenWithoutIdDTOTests
{
    [Test]
    public void TokenWithoutIdDTO_Should_SetAndGetTokenProperty()
    {
        // Arrange
        var dto = new TokenWithoutIdDTO();
        var token = "sampleToken";

        // Act
        dto.Token = token;

        // Assert
        Assert.That(dto.Token, Is.EqualTo(token));
    }

    [Test]
    public void TokenWithoutIdDTO_Should_SetAndGetTimeProperty()
    {
        // Arrange
        var dto = new TokenWithoutIdDTO();
        var time = DateTime.Now;

        // Act
        dto.Time = time;

        // Assert
        Assert.That(dto.Time, Is.EqualTo(time));
    }

    [Test]
    public void TokenWithoutIdDTO_Should_SetAndGetUserIdProperty()
    {
        // Arrange
        var dto = new TokenWithoutIdDTO();
        var userId = Guid.NewGuid();

        // Act
        dto.UserId = userId;

        // Assert
        Assert.That(dto.UserId, Is.EqualTo(userId));
    }

    [Test]
    public void TokenWithoutIdDTO_Should_HaveDefaultValues()
    {
        // Arrange
        var dto = new TokenWithoutIdDTO();

        // Assert
        Assert.That(dto.Token, Is.EqualTo(string.Empty));
        Assert.That(dto.Time, Is.EqualTo(default(DateTime)));
        Assert.That(dto.UserId, Is.EqualTo(default(Guid)));
    }
}
