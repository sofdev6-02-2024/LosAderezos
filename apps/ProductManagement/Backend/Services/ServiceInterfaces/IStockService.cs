using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IStockService
{
    public List<StockDTO> GetStocks();
    public StockDTO? GetStockById(Guid stockId);
    public List<StockDTO> GetStocksBySubsidiaryId(Guid subsidiaryId);
    public List<StockDTO> GetStocksByProductId(Guid productId);
    public StockDTO? GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId);
    public List<OtherSubsidiariesProductsDTO> GetOtherSubsidiariesProducts(Guid companyId, Guid productId);

    public StockDTO CreateStock(StockWithoutIDDTO stock);
    public StockDTO UpdateStock(StockWithoutIDDTO stock, Guid stockId);
    
}
