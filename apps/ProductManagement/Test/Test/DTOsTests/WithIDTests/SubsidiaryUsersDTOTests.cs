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
        Assert.AreEqual(userId, dto.UserId);
        Assert.AreEqual(subsidiaryId, dto.SubsidiaryId);
    }

    [Test]
    public void SubsidiaryUsersDTO_DefaultValues_AreGuidDefault()
    {
        // Act
        var dto = new SubsidiaryUsersDTO();

        // Assert
        Assert.AreEqual(Guid.Empty, dto.UserId);
        Assert.AreEqual(Guid.Empty, dto.SubsidiaryId);
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
        Assert.AreEqual(dto1.UserId, dto2.UserId);
        Assert.AreEqual(dto1.SubsidiaryId, dto2.SubsidiaryId);
    }
}
