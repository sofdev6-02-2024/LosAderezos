using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase
{
    private readonly IStockService _stockService;

    public StockController(IStockService stockService)
    {
        _stockService = stockService;
    }

    [HttpGet]
    public ActionResult<List<StockFullInfoDTO>> GetStocks()
    {
        var result = _stockService.GetStocks();
        return Ok(result);
    }

    [HttpGet("stock/{stockId}")]
    public ActionResult<StockFullInfoDTO> GetStockById(Guid stockId)
    {
        var result = _stockService.GetStockById(stockId);
        return Ok(result);
    }
    
    [HttpGet("subsidiary/{subsidiaryId}")]
    public ActionResult<List<StockFullInfoDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        var result = _stockService.GetStocksBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    
    [HttpGet("subsidiary/{subsidiaryId}/product/{productId}")]
    public ActionResult<StockFullInfoDTO> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
    {
        var result = _stockService.GetStocksBySubsidiaryAndProductId(subsidiaryId, productId);
        return Ok(result);
    }
    
    
    [HttpGet("company/{companyId}/product/{productId}")]
    public ActionResult<List<OtherSubsidiariesProductsDTO>> GetOtherSubsidiariesProducts(Guid companyId, Guid productId)
    {
        var result = _stockService.GetOtherSubsidiariesProducts(companyId, productId);
        return Ok(result);
    }
    
    [HttpGet("subsidiary/{subsidiaryId}/product-code/{productCode}")]
    public ActionResult<StockFullInfoDTO> GetStocksBySubsidiaryAndProductCode(Guid subsidiaryId, string productCode)
    {
        var result = _stockService.GetStocksBySubsidiaryAndProductCode(subsidiaryId, productCode);
        if (result == null)
        {
            return NotFound($"No stock found for subsidiaryId: {subsidiaryId} and productCode: {productCode}");
        }
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<StockFullInfoDTO> PostStock(StockWithoutIDDTO stock)
    {
        var result = _stockService.CreateStock(stock);
        return Ok(result);
    }

    [HttpPut("{stockId}")]
    public ActionResult<StockFullInfoDTO> PutStock(Guid stockId, StockWithoutIDDTO stock)
    {
        var result = _stockService.UpdateStock(stock, stockId);
        return Ok(result);
    }
    
    [HttpPut("Update/List")]
    public ActionResult<List<StockFullInfoDTO>> UpdateStocks([FromBody] List<StockDTO> stocks)
    {
        var result = _stockService.UpdateStocks(stocks);
        return Ok(result);
    }

}
