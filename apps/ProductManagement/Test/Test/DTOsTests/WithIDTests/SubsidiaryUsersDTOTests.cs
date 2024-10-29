using Backend.DTOs.WithID;

namespace Test.DTOsTests.WithIDTests;

public class SubsidiaryUsersDTOTests
{
    [Test]
    public void SubsidiaryUsersDTO_SetProperties_ReturnsCorrectValues()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var subsidiaryId = Guid.NewGuid();

        // Act
        var dto = new SubsidiaryUsersDTO
        {
            UserId = userId,
            SubsidiaryId = subsidiaryId
        };

        // Assert
        Assert.That(dto.UserId, Is.EqualTo(userId));
        Assert.That(dto.SubsidiaryId, Is.EqualTo(subsidiaryId));
    }

    [Test]
    public void SubsidiaryUsersDTO_DefaultValues_AreGuidDefault()
    {
        // Act
        var dto = new SubsidiaryUsersDTO();

        // Assert
        Assert.That(dto.UserId, Is.EqualTo(Guid.Empty));
        Assert.That(dto.SubsidiaryId, Is.EqualTo(Guid.Empty));
    }

    [Test]
    public void SubsidiaryUsersDTO_EqualityCheck_ReturnsTrueForSameValues()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var subsidiaryId = Guid.NewGuid();

        var dto1 = new SubsidiaryUsersDTO { UserId = userId, SubsidiaryId = subsidiaryId };
        var dto2 = new SubsidiaryUsersDTO { UserId = userId, SubsidiaryId = subsidiaryId };

        // Act & Assert
        Assert.That(dto2.UserId, Is.EqualTo(dto1.UserId));
        Assert.That(dto2.SubsidiaryId, Is.EqualTo(dto1.SubsidiaryId));
    }
}
