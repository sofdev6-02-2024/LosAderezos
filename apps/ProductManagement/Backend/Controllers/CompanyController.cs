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

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
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
