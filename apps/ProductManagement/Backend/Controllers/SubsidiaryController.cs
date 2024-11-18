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
    public async Task<ActionResult<List<SubsidiaryDTO>>> GetSubsidiary()
    {
        var subsidiaries = await _subsidiaryService.GetSubsidiaries();
        return Ok(subsidiaries);
    }

    [HttpGet("{subsidiaryId}")]
    public async Task<ActionResult<SubsidiaryDTO>> GetSubsidiary(Guid subsidiaryId)
    {
        var subsidiary = await _subsidiaryService.GetSubsidiaryById(subsidiaryId);
        return Ok(subsidiary);
    }


    [HttpPost]
    public async Task<ActionResult<List<SubsidiaryDTO>>> CreateSubsidiary(SubsidiaryWithoutDTO subsidiary)
    {
        var subsidiaryCreated = await _subsidiaryService.CreateSubsidiary(subsidiary);
        return Ok(subsidiary);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<SubsidiaryDTO>>> UpdateSubsidiary(SubsidiaryDTO subsidiary)
    {
        var subsidiaryCreated = await _subsidiaryService.UpdateSubsidiary(subsidiary);
        return Ok(subsidiary);
    }
    
}