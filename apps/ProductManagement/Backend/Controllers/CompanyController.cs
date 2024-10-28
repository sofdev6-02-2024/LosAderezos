using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/productManagement/[controller]")]

public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CompanyDTO>>> GetCompanies()
    {
        var result = await _companyService.GetCompanies();
        return Ok(result);
    }
    
    [HttpGet("{companyId}")]
    public async Task<ActionResult<CompanyDTO>> GetCompanyById(Guid companyId)
    {
        var result = await _companyService.GetCompanyById(companyId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<CompanyDTO>>> CreateCompany(CompanyWithoutIDDTO company)
    {
        var result = await _companyService.CreateCompany(company);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<CompanyDTO>>> UpdateCompany(CompanyDTO company)
    {
        var result = await _companyService.UpdateCompany(company);
        return Ok(result);
    }
}
