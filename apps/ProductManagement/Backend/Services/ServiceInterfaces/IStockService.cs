using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IStockService
{
    public List<StockFullInfoDTO> GetStocks();
    public StockFullInfoDTO? GetStockById(Guid stockId);
    public List<StockFullInfoDTO> GetStocksBySubsidiaryId(Guid subsidiaryId);
    public List<StockFullInfoDTO> GetStocksByProductId(Guid productId);
    public StockFullInfoDTO? GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId);
    public List<OtherSubsidiariesProductsDTO> GetOtherSubsidiariesProducts(Guid companyId, Guid productId);

    public StockFullInfoDTO CreateStock(StockWithoutIDDTO stock);
    public StockFullInfoDTO UpdateStock(StockWithoutIDDTO stock, Guid stockId);
    public List<StockFullInfoDTO> UpdateStocks(List<StockDTO> stocks);
    public StockFullInfoDTO? GetStocksBySubsidiaryAndProductCode(Guid subsidiaryId, int productCode);

}
