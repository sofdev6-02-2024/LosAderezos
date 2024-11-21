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
    private readonly IUserAPIService _userApiService;

    public StockController(IStockService stockService, IUserAPIService userApiService)
    {
        _stockService = stockService;
        _userApiService = userApiService;
    }

    [HttpGet]
    public ActionResult<List<StockDTO>> GetStocks()
    {
        if (!Request.Headers.ContainsKey("userId") || !Request.Headers.ContainsKey("token"))
        {
            return BadRequest("no header provided");
        }

        if (!Guid.TryParse(Request.Headers["userId"], out Guid headerUserId))
        {
            return Unauthorized("Invalid userId");
        }
        var toVerify = new ValidateTokenDTO()
        {
            UserId = headerUserId,
            Token = Request.Headers["token"]
        };
        if (!_userApiService.IsTokenValid(toVerify).Result)
        {
            return Unauthorized("Invalid token");
        }

        if (_userApiService.IsUserOwnerOrHigher(toVerify.UserId).Result == true)
        {
            return Unauthorized("you are not an admin nor owner");
        }

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
        
        if (!Request.Headers.ContainsKey("userId") || !Request.Headers.ContainsKey("token"))
        {
            return BadRequest("no header provided");
        }

        if (!Guid.TryParse(Request.Headers["userId"], out Guid headerUserId))
        {
            return Unauthorized("Invalid userId");
        }
        var toVerify = new ValidateTokenDTO()
        {
            UserId = headerUserId,
            Token = Request.Headers["token"]
        };
        if (!_userApiService.IsTokenValid(toVerify).Result)
        {
            return Unauthorized("Invalid token");
        }
        var result = _stockService.GetStocksBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    
    [HttpGet("subsidiary/{subsidiaryId}/product/{productId}")]
    public ActionResult<StockDTO> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
    {
        
        if (!Request.Headers.ContainsKey("userId") || !Request.Headers.ContainsKey("token"))
        {
            return BadRequest("no header provided");
        }

        if (!Guid.TryParse(Request.Headers["userId"], out Guid headerUserId))
        {
            return Unauthorized("Invalid userId");
        }
        var toVerify = new ValidateTokenDTO()
        {
            UserId = headerUserId,
            Token = Request.Headers["token"]
        };
        if (!_userApiService.IsTokenValid(toVerify).Result)
        {
            return Unauthorized("Invalid token");
        }
        var result = _stockService.GetStocksBySubsidiaryAndProductId(subsidiaryId, productId);
        return Ok(result);
    }
    
    
    [HttpGet("company/{companyId}/product/{productId}")]
    public ActionResult<List<OtherSubsidiariesProductsDTO>> GetOtherSubsidiariesProducts(Guid companyId, Guid productId)
    {
        if (!Request.Headers.ContainsKey("userId") || !Request.Headers.ContainsKey("token"))
        {
            return BadRequest("no header provided");
        }

        if (!Guid.TryParse(Request.Headers["userId"], out Guid headerUserId))
        {
            return Unauthorized("Invalid userId");
        }
        var toVerify = new ValidateTokenDTO()
        {
            UserId = headerUserId,
            Token = Request.Headers["token"]
        };
        if (!_userApiService.IsTokenValid(toVerify).Result)
        {
            return Unauthorized("Invalid token");
        }
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
}
