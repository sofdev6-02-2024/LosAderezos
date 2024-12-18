using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;


[ApiController]
[Route("[controller]")]
public class SubsidiaryController: ControllerBase
{
    private readonly ISubsidiaryService _subsidiaryService;

    public SubsidiaryController(ISubsidiaryService subsidiaryService)
    {
        _subsidiaryService = subsidiaryService;
    }

    [HttpGet]
    public ActionResult<List<SubsidiaryDTO>> GetSubsidiary()
    {
        var subsidiaries = _subsidiaryService.GetSubsidiaries();
        return Ok(subsidiaries);
    }

    [HttpGet("{subsidiaryId}")]
    public ActionResult<SubsidiaryDTO> GetSubsidiary(Guid subsidiaryId)
    {
        var subsidiary = _subsidiaryService.GetSubsidiaryById(subsidiaryId);
        return Ok(subsidiary);
    }
    
    
    [HttpGet("company/{companyId}")]
    public ActionResult<List<SubsidiaryDTO>> GetSubsidiariesByCompanyId(Guid companyId)
    {
        var subsidiary = _subsidiaryService.GetSubsidiariesByCompanyId(companyId);
        return Ok(subsidiary);
    }


    [HttpPost]
    public ActionResult<List<SubsidiaryDTO>> CreateSubsidiary(SubsidiaryWithoutDTO subsidiary)
    {
        var subsidiaryCreated = _subsidiaryService.CreateSubsidiary(subsidiary);
        return Ok(subsidiary);
    }
    
    [HttpPut]
    public ActionResult<List<SubsidiaryDTO>> UpdateSubsidiary(SubsidiaryDTO subsidiary)
    {
        var subsidiaryCreated = _subsidiaryService.UpdateSubsidiary(subsidiary);
        return Ok(subsidiary);
    }
    
    [HttpDelete("{subsidiaryId}")]
    public ActionResult<SubsidiaryDTO> DeleteSubsidiary(Guid subsidiaryId)
    {
        var subsidiary = _subsidiaryService.DeleteSubsidiaryById(subsidiaryId);
        return Ok(subsidiary);
    }
    
}
