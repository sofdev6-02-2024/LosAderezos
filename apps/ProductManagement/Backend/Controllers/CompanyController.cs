using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]

public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IUserAPIService _userApiService;


    public CompanyController(ICompanyService companyService, IUserAPIService userApiService)
    {
        _companyService = companyService;
        _userApiService = userApiService;
    }

    [HttpGet]
    public ActionResult<List<CompanyDTO>> GetCompanies()
    {
        var result = _companyService.GetCompanies();
        return Ok(result);
    }
    
    [HttpGet("{companyId}")]
    public ActionResult<CompanyDTO> GetCompanyById(Guid companyId)
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

        var result = _companyService.GetCompanyById(companyId);
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<List<CompanyDTO>> CreateCompany(CompanyWithoutIDDTO company)
    {
        var result = _companyService.CreateCompany(company);
        return Ok(result);
    }
    
    [HttpPut]
    public ActionResult<List<CompanyDTO>> UpdateCompany(CompanyDTO company)
    {
        var result = _companyService.UpdateCompany(company);
        return Ok(result);
    }
}
