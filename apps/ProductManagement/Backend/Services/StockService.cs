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
    private readonly IMapper _mapper;

    public StockService(IStockDAO stockDao, IMapper mapper)
    {
        _stockDao = stockDao;
        _mapper = mapper;
    }

    public async Task<List<StockDTO>> GetStocks()
    {
        return _stockDao.ReadAll().Select(_mapper.Map<StockDTO>).ToList();
    }

    public async Task<StockDTO?> GetStockById(Guid stockId)
    {
        return _mapper.Map<StockDTO>(_stockDao.Read(stockId));
    }

    public async Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        return _stockDao.ReadAll().Where(s => s.SubsidiaryId == subsidiaryId).Select(s => _mapper.Map<StockDTO>(s)).ToList();
    }

    public async Task<StockDTO> CreateStock(StockWithoutIDDTO stock)
    {
        Guid guid = Guid.NewGuid();
        _stockDao.Create(_mapper.Map<Stock>((stock, guid)));
        return _mapper.Map<StockDTO>(_stockDao.Read(guid));
    }

    public async Task<StockDTO> UpdateStock(StockDTO stock)
    {
        _stockDao.Update(_mapper.Map<Stock>(stock));
        return _mapper.Map<StockDTO>(_stockDao.Read(stock.StockId));
    }
}
