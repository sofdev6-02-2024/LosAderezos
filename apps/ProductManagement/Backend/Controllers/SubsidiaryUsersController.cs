using Backend.DTOs.WithID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SubsidiaryUsersController : ControllerBase
{
    private readonly ISubsidiaryUsersService _subsidiaryUsersService;
    private readonly IUserAPIService _userApiService;


    public SubsidiaryUsersController(ISubsidiaryUsersService subsidiaryUsersService, IUserAPIService userApiService)
    {
        _subsidiaryUsersService = subsidiaryUsersService;
        _userApiService = userApiService;
    }

    [HttpGet("subsidiary/{subsidiaryId}")]
    public ActionResult<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId);
        return Ok(result);
    }
    
    [HttpGet("user/{userId}")]
    public ActionResult<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersByUserId(Guid userId)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersByUserId(userId);
        return Ok(result);
    }
    
    [HttpPost]
    public ActionResult<SubsidiaryUsersDTO> GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.GetSubsidiaryUsersByBothIds(subsidiaryUsers);
        return Ok(result);
    }
    
    [HttpPost("/create")]
    public ActionResult<SubsidiaryUsersDTO> CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.CreateSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
    
    [HttpPost("/create/list")]
    public ActionResult<List<SubsidiaryUsersDTO>> CreateSubsidiaryUsersList(UserSubsidiaryCreateListDTO subsidiaryUsers)
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

        if (_userApiService.IsUserAdminOrHigher(toVerify.UserId).Result == true)
        {
            return Unauthorized("you are not an admin nor owner");
        }
        var results = new List<SubsidiaryUsersDTO>();
        foreach (Guid userId in subsidiaryUsers.UserIds)
        {
            results.Add(_subsidiaryUsersService.CreateSubsidiaryUsers(new SubsidiaryUsersDTO()
            {
                UserId = userId,
                SubsidiaryId = subsidiaryUsers.SubsidiaryId,
            }));    
        }
        return Ok(results);
    }
    
    [HttpDelete]
    public ActionResult<bool> DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        var result = _subsidiaryUsersService.DeleteSubsidiaryUsers(subsidiaryUsers);
        return Ok(result);
    }
    
}
