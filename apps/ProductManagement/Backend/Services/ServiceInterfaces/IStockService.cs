using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IStockService
{
    public Task<List<StockDTO>> GetStocks();
    public Task<StockDTO?> GetStockById(Guid stockId);
    public Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId);
    public Task<StockDTO> CreateStock(StockWithoutIDDTO stock);
    public Task<StockDTO> UpdateStock(StockDTO stock);
    
}