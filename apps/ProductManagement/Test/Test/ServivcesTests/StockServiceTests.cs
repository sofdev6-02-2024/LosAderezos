using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

public class StockServiceTests
{
    private Mock<IStockDAO> _stockDaoMock;
    private Mock<IMapper> _mapperMock;
    private StockService _service;

    [SetUp]
    public void SetUp()
    {
        _stockDaoMock = new Mock<IStockDAO>();
        _mapperMock = new Mock<IMapper>();
        _service = new StockService(_stockDaoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetStocks_ReturnsMappedList()
    {
        // Arrange
        var stocks = new List<Stock> 
        {
            new Stock { StockId = Guid.NewGuid(), Quantity = 100 }
        };
        var expectedDtos = stocks.Select(s => new StockDTO { StockId = s.StockId, Quantity = s.Quantity }).ToList();

        _stockDaoMock.Setup(dao => dao.ReadAll()).Returns(stocks);
        _mapperMock.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>())).Returns((Stock source) => new StockDTO { StockId = source.StockId, Quantity = source.Quantity });

        // Act
        var result = await _service.GetStocks();

        // Assert
        Assert.AreEqual(expectedDtos.Count, result.Count);
        Assert.AreEqual(expectedDtos[0].StockId, result[0].StockId);
        Assert.AreEqual(expectedDtos[0].Quantity, result[0].Quantity);
    }

    [Test]
    public async Task GetStockById_ReturnsMappedDTO()
    {
        // Arrange
        var stockId = Guid.NewGuid();
        var subsidiaryId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var stock = new Stock { StockId = stockId, Quantity = 100, SubsidiaryId = subsidiaryId, ProductId = productId, Code = 4 };
        var expectedDto = new StockDTO { StockId = stockId, Quantity = 100 , SubsidiaryId = subsidiaryId, ProductId = productId, Code = 4 };

        _stockDaoMock.Setup(dao => dao.Read(stockId)).Returns(stock);
        _mapperMock.Setup(m => m.Map<StockDTO>(stock)).Returns(expectedDto);

        // Act
        var result = await _service.GetStockById(stockId);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.StockId, Is.EqualTo(expectedDto.StockId));
        Assert.That(result.Quantity, Is.EqualTo(expectedDto.Quantity));
    }

    [Test]
    public async Task GetStocksBySubsidiaryId_ReturnsFilteredMappedList()
    {
        // Arrange
        var subsidiaryId = Guid.NewGuid();
        var stocks = new List<Stock> 
        {
            new Stock { StockId = Guid.NewGuid(), SubsidiaryId = subsidiaryId, Quantity = 50 },
            new Stock { StockId = Guid.NewGuid(), SubsidiaryId = Guid.NewGuid(), Quantity = 75 } // different subsidiary
        };
        var expectedDtos = stocks.Where(s => s.SubsidiaryId == subsidiaryId)
                                 .Select(s => new StockDTO { StockId = s.StockId, Quantity = s.Quantity })
                                 .ToList();

        _stockDaoMock.Setup(dao => dao.ReadAll()).Returns(stocks);
        _mapperMock.Setup(m => m.Map<StockDTO>(It.IsAny<Stock>())).Returns((Stock source) => new StockDTO { StockId = source.StockId, Quantity = source.Quantity });

        // Act
        var result = await _service.GetStocksBySubsidiaryId(subsidiaryId);

        // Assert
        Assert.AreEqual(expectedDtos.Count, result.Count);
        Assert.IsTrue(result.All(dto => dto.StockId == expectedDtos.First().StockId && dto.Quantity == expectedDtos.First().Quantity));
    }

    [Test]
    public async Task CreateStock_CreatesAndReturnsMappedDTO()
    {
        // Arrange
        var stockWithoutIdDto = new StockWithoutIDDTO { Quantity = 200 };
        var stockId = Guid.NewGuid();
        var stock = new Stock { StockId = stockId, Quantity = 200 };
        var expectedDto = new StockDTO { StockId = stockId, Quantity = 200 };

        _mapperMock.Setup(m => m.Map<Stock>(It.IsAny<(SubsidiaryWithoutDTO, Guid)>())).Returns(stock);
        _stockDaoMock.Setup(dao => dao.Create(stock));
        _stockDaoMock.Setup(dao => dao.Read(It.IsAny<Guid>())).Returns(stock);
        _mapperMock.Setup(m => m.Map<StockDTO>(stock)).Returns(expectedDto);

        // Act
        var result = await _service.CreateStock(stockWithoutIdDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedDto.StockId, result.StockId);
        Assert.AreEqual(expectedDto.Quantity, result.Quantity);
    }

    [Test]
    public async Task UpdateStock_UpdatesAndReturnsMappedDTO()
    {
        // Arrange
        var stockDto = new StockDTO { StockId = Guid.NewGuid(), Quantity = 300 };
        var stock = new Stock { StockId = stockDto.StockId, Quantity = 300 };

        _mapperMock.Setup(m => m.Map<Stock>(stockDto)).Returns(stock);
        _stockDaoMock.Setup(dao => dao.Update(stock));
        _stockDaoMock.Setup(dao => dao.Read(stockDto.StockId)).Returns(stock);
        _mapperMock.Setup(m => m.Map<StockDTO>(stock)).Returns(stockDto);

        // Act
        var result = await _service.UpdateStock(stockDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(stockDto.StockId, result.StockId);
        Assert.AreEqual(stockDto.Quantity, result.Quantity);
    }    
}
