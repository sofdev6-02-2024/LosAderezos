using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class StockService : IStockService
{
    private readonly IDAO<Stock> _stockDao;
    private readonly ISingleDAO<Stock> _singleStockDao;
    private readonly IMapper _mapper;

    public StockService(IDAO<Stock> stockDao, IMapper mapper, ISingleDAO<Stock> singleStockDao)
    {
        _stockDao = stockDao;
        _mapper = mapper;
        _singleStockDao = singleStockDao;
    }

    public async Task<List<StockDTO>> GetStocks()
    {
        return _stockDao.ReadAll().Select(_mapper.Map<Stock, StockDTO>).ToList();
    }

    public async Task<StockDTO?> GetStockById(Guid stockId)
    {
        return _mapper.Map<Stock, StockDTO>(_singleStockDao.Read(stockId));
    }

    public async Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        return _stockDao.ReadAll().Where(s => s.SubsidiaryId == subsidiaryId).Select(s => _mapper.Map<StockDTO>(s)).ToList();
    }

    public async Task<StockDTO> CreateStock(StockWithoutIDDTO stock)
    {
        return _mapper.Map<StockDTO>(_singleStockDao.Create(_mapper.Map<Stock>(stock)));
    }

    public async Task<StockDTO> UpdateStock(StockDTO stock)
    {
        return _mapper.Map<StockDTO>(_singleStockDao.Create(_mapper.Map<Stock>(stock)));
    }
}
