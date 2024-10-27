using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

public class SubsidiaryUsersServiceTests
{
    private Mock<ISubsidiaryUsersDAO> _subsidiaryUsersDaoMock;
    private Mock<IMapper> _mapperMock;
    private SubsidiaryUsersService _service;

    [SetUp]
    public void SetUp()
    {
        _subsidiaryUsersDaoMock = new Mock<ISubsidiaryUsersDAO>();
        _mapperMock = new Mock<IMapper>();
        _service = new SubsidiaryUsersService(_subsidiaryUsersDaoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetSubsidiaryUsersByUserId_ReturnsMappedList()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var subsidiaryUsers = new List<SubsidiaryUsers>
        {
            new SubsidiaryUsers { SubsidiaryId = Guid.NewGuid(), UserId = userId },
            new SubsidiaryUsers { SubsidiaryId = Guid.NewGuid(), UserId = userId }
        };
        var expectedDtos = subsidiaryUsers.Select(u => new SubsidiaryUsersDTO { SubsidiaryId = u.SubsidiaryId, UserId = u.UserId }).ToList();

        _subsidiaryUsersDaoMock.Setup(dao => dao.GetSubsidiaryUsersByUserId(userId)).Returns(subsidiaryUsers);
        _mapperMock.Setup(m => m.Map<SubsidiaryUsersDTO>(It.IsAny<SubsidiaryUsers>()))
            .Returns((SubsidiaryUsers source) => new SubsidiaryUsersDTO { SubsidiaryId = source.SubsidiaryId, UserId = source.UserId });

        // Act
        var result = await _service.GetSubsidiaryUsersByUserId(userId);

        // Assert
        Assert.AreEqual(expectedDtos.Count, result.Count);
        Assert.AreEqual(expectedDtos[0].SubsidiaryId, result[0].SubsidiaryId);
    }

    [Test]
    public async Task GetSubsidiaryUsersBySubsidiaryId_ReturnsMappedList()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        var subsidiaryUsers = new List<SubsidiaryUsers>
        {
            new SubsidiaryUsers { SubsidiaryId = subsidiaryId, UserId = Guid.NewGuid() },
            new SubsidiaryUsers { SubsidiaryId = subsidiaryId, UserId = Guid.NewGuid() }
        };
        var expectedDtos = subsidiaryUsers.Select(u => new SubsidiaryUsersDTO { SubsidiaryId = u.SubsidiaryId, UserId = u.UserId }).ToList();

        _subsidiaryUsersDaoMock.Setup(dao => dao.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId)).Returns(subsidiaryUsers);
        _mapperMock.Setup(m => m.Map<SubsidiaryUsersDTO>(It.IsAny<SubsidiaryUsers>()))
            .Returns((SubsidiaryUsers source) => new SubsidiaryUsersDTO { SubsidiaryId = source.SubsidiaryId, UserId = source.UserId });

        // Act
        var result = await _service.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId);

        // Assert
        Assert.AreEqual(expectedDtos.Count, result.Count);
        Assert.AreEqual(expectedDtos[0].UserId, result[0].UserId);
    }

    [Test]
    public async Task GetSubsidiaryUsersByBothIds_ReturnsMappedDTO()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var subsidiaryUsers = new SubsidiaryUsers { SubsidiaryId = subsidiaryId, UserId = userId };
        var expectedDto = new SubsidiaryUsersDTO { SubsidiaryId = subsidiaryId, UserId = userId };

        _subsidiaryUsersDaoMock.Setup(dao => dao.Read(subsidiaryId, userId)).Returns(subsidiaryUsers);
        _mapperMock.Setup(m => m.Map<SubsidiaryUsersDTO>(subsidiaryUsers)).Returns(expectedDto);

        // Act
        var result = await _service.GetSubsidiaryUsersByBothIds(expectedDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDto.SubsidiaryId, result.SubsidiaryId);
        Assert.AreEqual(expectedDto.UserId, result.UserId);
    }

    [Test]
    public async Task CreateSubsidiaryUsers_CreatesAndReturnsMappedDTO()
    {
        // Arrange
        var subsidiaryUsersDto = new SubsidiaryUsersDTO { SubsidiaryId = Guid.NewGuid(), UserId = Guid.NewGuid() };
        var subsidiaryUsers = new SubsidiaryUsers { SubsidiaryId = subsidiaryUsersDto.SubsidiaryId, UserId = subsidiaryUsersDto.UserId };

        _mapperMock.Setup(m => m.Map<SubsidiaryUsers>(subsidiaryUsersDto)).Returns(subsidiaryUsers);
        _subsidiaryUsersDaoMock.Setup(dao => dao.Create(subsidiaryUsers));
        _subsidiaryUsersDaoMock.Setup(dao => dao.Read(subsidiaryUsersDto.SubsidiaryId, subsidiaryUsersDto.UserId)).Returns(subsidiaryUsers);
        _mapperMock.Setup(m => m.Map<SubsidiaryUsersDTO>(subsidiaryUsers)).Returns(subsidiaryUsersDto);

        // Act
        var result = await _service.CreateSubsidiaryUsers(subsidiaryUsersDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(subsidiaryUsersDto.SubsidiaryId, result.SubsidiaryId);
        Assert.AreEqual(subsidiaryUsersDto.UserId, result.UserId);
    }

    [Test]
    public async Task DeleteSubsidiaryUsers_DeletesAndReturnsTrue()
    {
        // Arrange
        var subsidiaryUsersDto = new SubsidiaryUsersDTO { SubsidiaryId = Guid.NewGuid(), UserId = Guid.NewGuid() };

        _subsidiaryUsersDaoMock.Setup(dao => dao.Delete(subsidiaryUsersDto.SubsidiaryId, subsidiaryUsersDto.UserId)).Returns(true);

        // Act
        var result = await _service.DeleteSubsidiaryUsers(subsidiaryUsersDto);

        // Assert
        Assert.IsTrue(result);
    }
}
