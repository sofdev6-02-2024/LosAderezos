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
    public ActionResult<List<StockDTO>> GetStocks()
    {
        var result = _stockService.GetStocks();
        return Ok(result);
    }

    [HttpGet("stock/{stockId}")]
    public ActionResult<StockDTO> GetStockById(Guid stockId)
    {
        var result = _stockService.GetStockById(stockId);
        return Ok(result);
    }
    
    [HttpGet("subsidiary/{subsidiaryId}")]
    public ActionResult<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        var result = _stockService.GetStocksBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    
    [HttpGet("subsidiary/{subsidiaryId}/product/{productId}")]
    public ActionResult<StockDTO> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
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
    
    [HttpPost]
    public ActionResult<StockDTO> PostStock(StockWithoutIDDTO stock)
    {
        var result = _stockService.CreateStock(stock);
        return Ok(result);
    }

    [HttpPut("{stockId}")]
    public ActionResult<StockDTO> PutStock(Guid stockId, StockWithoutIDDTO stock)
    {
        var result = _stockService.UpdateStock(stock, stockId);
        return Ok(result);
    }
    
    [HttpPut("update-multiple")]
    public ActionResult<List<StockDTO>> UpdateStocks([FromBody] List<StockDTO> stocks)
    {
        var result = _stockService.UpdateStocks(stocks);
        return Ok(result);
    }

}
