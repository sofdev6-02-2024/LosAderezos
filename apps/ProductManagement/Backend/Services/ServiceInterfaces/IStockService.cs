using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IStockService
{
    public Task<List<StockDTO>> GetStocks();
    public Task<StockDTO?> GetStockById(Guid stockId);
    public Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId);
    public Task<List<StockDTO>> GetStocksByProductId(Guid productId);
    public Task<StockDTO?> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId);
    public Task<List<OtherSubsidiariesProductsDTO>> GetOtherSubsidiariesProducts(Guid companyId, Guid productId);

    public Task<StockDTO> CreateStock(StockWithoutIDDTO stock);
    public Task<StockDTO> UpdateStock(StockWithoutIDDTO stock, Guid stockId);
    
}
