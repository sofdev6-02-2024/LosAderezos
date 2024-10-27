using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

public class SubsidiaryServiceTests
{
    private Mock<ISubsidiaryDAO> _subsidiaryDaoMock;
    private Mock<IMapper> _mapperMock;
    private SubsidiaryService _service;

    [SetUp]
    public void SetUp()
    {
        _subsidiaryDaoMock = new Mock<ISubsidiaryDAO>();
        _mapperMock = new Mock<IMapper>();
        _service = new SubsidiaryService(_subsidiaryDaoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetSubsidiaries_ReturnsMappedList()
    {
        // Arrange
        var subsidiaries = new List<Subsidiary>
        {
            new Subsidiary { SubsidiaryId = Guid.NewGuid(), Name = "Subsidiary 1" },
            new Subsidiary { SubsidiaryId = Guid.NewGuid(), Name = "Subsidiary 2" }
        };
        var expectedDtos = subsidiaries.Select(s => new SubsidiaryDTO { SubsidiaryId = s.SubsidiaryId, Name = s.Name }).ToList();

        _subsidiaryDaoMock.Setup(dao => dao.ReadAll()).Returns(subsidiaries);
        _mapperMock.Setup(m => m.Map<SubsidiaryDTO>(It.IsAny<Subsidiary>())).Returns((Subsidiary source) => new SubsidiaryDTO { SubsidiaryId = source.SubsidiaryId, Name = source.Name });

        // Act
        var result = await _service.GetSubsidiaries();

        // Assert
        Assert.AreEqual(expectedDtos.Count, result.Count);
        Assert.AreEqual(expectedDtos[0].SubsidiaryId, result[0].SubsidiaryId);
        Assert.AreEqual(expectedDtos[0].Name, result[0].Name);
    }

    [Test]
    public async Task GetSubsidiaryById_ReturnsMappedDTO()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        var subsidiary = new Subsidiary { SubsidiaryId = subsidiaryId, Name = "Subsidiary" };
        var expectedDto = new SubsidiaryDTO { SubsidiaryId = subsidiaryId, Name = "Subsidiary" };

        _subsidiaryDaoMock.Setup(dao => dao.Read(subsidiaryId)).Returns(subsidiary);
        _mapperMock.Setup(m => m.Map<SubsidiaryDTO>(subsidiary)).Returns(expectedDto);

        // Act
        var result = await _service.GetSubsidiaryById(subsidiaryId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDto.SubsidiaryId, result.SubsidiaryId);
        Assert.AreEqual(expectedDto.Name, result.Name);
    }

    [Test]
    public async Task CreateSubsidiary_CreatesAndReturnsMappedDTO()
    {
        // Arrange
        var subsidiaryWithoutIdDto = new SubsidiaryWithoutDTO { Name = "New Subsidiary" };
        var subsidiaryId = Guid.NewGuid();
        var subsidiary = new Subsidiary { SubsidiaryId = subsidiaryId, Name = "New Subsidiary" };
        var expectedDto = new SubsidiaryDTO { SubsidiaryId = subsidiaryId, Name = "New Subsidiary" };

        _mapperMock.Setup(m => m.Map<Subsidiary>(It.IsAny<(SubsidiaryWithoutDTO, Guid)>())).Returns(subsidiary);
        _subsidiaryDaoMock.Setup(dao => dao.Create(subsidiary));
        _subsidiaryDaoMock.Setup(dao => dao.Read(It.IsAny<Guid>())).Returns(subsidiary);
        _mapperMock.Setup(m => m.Map<SubsidiaryDTO>(subsidiary)).Returns(expectedDto);

        // Act
        var result = await _service.CreateSubsidiary(subsidiaryWithoutIdDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDto.SubsidiaryId, result.SubsidiaryId);
        Assert.AreEqual(expectedDto.Name, result.Name);
    }

    [Test]
    public async Task UpdateSubsidiary_UpdatesAndReturnsMappedDTO()
    {
        // Arrange
        var subsidiaryDto = new SubsidiaryDTO { SubsidiaryId = Guid.NewGuid(), Name = "Updated Subsidiary" };
        var subsidiary = new Subsidiary { SubsidiaryId = subsidiaryDto.SubsidiaryId, Name = "Updated Subsidiary" };

        _mapperMock.Setup(m => m.Map<Subsidiary>(subsidiaryDto)).Returns(subsidiary);
        _subsidiaryDaoMock.Setup(dao => dao.Update(subsidiary));
        _subsidiaryDaoMock.Setup(dao => dao.Read(subsidiaryDto.SubsidiaryId)).Returns(subsidiary);
        _mapperMock.Setup(m => m.Map<SubsidiaryDTO>(subsidiary)).Returns(subsidiaryDto);

        // Act
        var result = await _service.UpdateSubsidiary(subsidiaryDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(subsidiaryDto.SubsidiaryId, result.SubsidiaryId);
        Assert.AreEqual(subsidiaryDto.Name, result.Name);
    }
}
