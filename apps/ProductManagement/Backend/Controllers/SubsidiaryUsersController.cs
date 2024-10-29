using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/productManagement/[controller]")]
public class SubsidiaryUsersController : ControllerBase
{
    private readonly ISubsidiaryUsersService _subsidiaryUsersService;

    public SubsidiaryUsersController(ISubsidiaryUsersService subsidiaryUsersService)
    {
        _subsidiaryUsersService = subsidiaryUsersService;
    }

    [HttpGet("{subsidiaryId}")]
    public async Task<ActionResult<List<SubsidiaryUsersDTO>>> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    [HttpGet("{userId}")]
    public async Task<ActionResult<List<SubsidiaryUsersDTO>>> GetSubsidiaryUsersByUserId(Guid userId)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersByUserId(userId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<SubsidiaryUsersDTO>> GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersByBothIds(subsidiaryUsers);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<SubsidiaryUsersDTO>> CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.CreateSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.DeleteSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
}
