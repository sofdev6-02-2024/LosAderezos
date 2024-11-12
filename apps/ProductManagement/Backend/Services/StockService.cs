using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class StockService : IStockService
{
    private readonly IStockDAO _stockDao;
    private readonly IProductDAO _productDao;
    private readonly IMapper _mapper;

    public StockService(IStockDAO stockDao, IMapper mapper, IProductDAO productDao)
    {
        _stockDao = stockDao;
        _mapper = mapper;
        _productDao = productDao;
    }

    public async Task<List<StockDTO>> GetStocks()
    {
        return _stockDao.ReadAll().Select(stock =>
        {
            var product = _productDao.Read(stock.ProductId);
            return _mapper.Map<StockDTO>((stock, product));
        }).ToList();
    }

    public async Task<StockDTO?> GetStockById(Guid stockId)
    {
        var stock = _stockDao.Read(stockId);
        return _mapper.Map<StockDTO>((stock, _productDao.Read(stock.ProductId)));
    }

    public async Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        return _stockDao.ReadAll().Where(s => s.SubsidiaryId == subsidiaryId).Select(s => {
            var product = _productDao.Read(s.ProductId);
            return _mapper.Map<StockDTO>((s, product));
        }).ToList();
    }

    public async Task<StockDTO> CreateStock(StockWithoutIDDTO stock)
    {
        Guid guid = Guid.NewGuid();
        _stockDao.Create(_mapper.Map<Stock>((stock, guid)));
        var createdStock = _stockDao.Read(guid);
        return _mapper.Map<StockDTO>((createdStock, _productDao.Read(stock.ProductId)));
    }

    public async Task<StockDTO> UpdateStock(StockDTO stock)
    {
        _stockDao.Update(_mapper.Map<Stock>(stock));
        var updatedStock = _stockDao.Read(stock.StockId);
        return _mapper.Map<StockDTO>((updatedStock, _productDao.Read(stock.ProductId)));
    }
}
