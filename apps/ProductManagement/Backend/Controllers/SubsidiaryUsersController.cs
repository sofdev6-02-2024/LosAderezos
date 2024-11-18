using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SubsidiaryUsersController : ControllerBase
{
    private readonly ISubsidiaryUsersService _subsidiaryUsersService;

    public SubsidiaryUsersController(ISubsidiaryUsersService subsidiaryUsersService)
    {
        _subsidiaryUsersService = subsidiaryUsersService;
    }

    [HttpGet("subsidiary/{subsidiaryId}")]
    public async Task<ActionResult<List<SubsidiaryUsersDTO>>> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId)
    {
        var result = await _subsidiaryUsersService.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<SubsidiaryUsersDTO>>> GetSubsidiaryUsersByUserId(Guid userId)
    {
        var result = await _subsidiaryUsersService.GetSubsidiaryUsersByUserId(userId);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<SubsidiaryUsersDTO>> GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = await _subsidiaryUsersService.GetSubsidiaryUsersByBothIds(subsidiaryUsers);
        return Ok(result);
    }
    
    [HttpPost("/create")]
    public async Task<ActionResult<SubsidiaryUsersDTO>> CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = await _subsidiaryUsersService.CreateSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
    
    [HttpPost("/create/list")]
    public async Task<ActionResult<List<SubsidiaryUsersDTO>>> CreateSubsidiaryUsersList(UserSubsidiaryCreateListDTO subsidiaryUsers)
    {
        var results = new List<SubsidiaryUsersDTO>();
        foreach (Guid userId in subsidiaryUsers.UserIds)
        {
            results.Add(_subsidiaryUsersService.CreateSubsidiaryUsers(new SubsidiaryUsersDTO()
            {
                UserId = userId,
                SubsidiaryId = subsidiaryUsers.SubsidiaryId,
            }).Result);    
        }
        return Ok(results);
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = await _subsidiaryUsersService.DeleteSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
}
