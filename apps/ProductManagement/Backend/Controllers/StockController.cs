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
    public async Task<ActionResult<List<StockDTO>>> GetStocks()
    {
        var result = await _stockService.GetStocks();
        return Ok(result);
    }

    [HttpGet("stock/{stockId}")]
    public async Task<ActionResult<StockDTO>> GetStockById(Guid stockId)
    {
        var result = await _stockService.GetStockById(stockId);
        return Ok(result);
    }
    
    [HttpGet("subsidiary/{subsidiaryId}")]
    public async Task<ActionResult<List<StockDTO>>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        var result = await _stockService.GetStocksBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    
    [HttpGet("subsidiary/{subsidiaryId}/product/{productId}")]
    public async Task<ActionResult<StockDTO>> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
    {
        var result = await _stockService.GetStocksBySubsidiaryAndProductId(subsidiaryId, productId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<StockDTO>> PostStock(StockWithoutIDDTO stock)
    {
        var result = await _stockService.CreateStock(stock);
        return Ok(result);
    }

    [HttpPut("{stockId}")]
    public async Task<ActionResult<StockDTO>> PutStock(Guid stockId, StockWithoutIDDTO stock)
    {
        var result = await _stockService.UpdateStock(stock, stockId);
        return Ok(result);
    }
}
