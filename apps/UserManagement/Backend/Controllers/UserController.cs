using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAllUsers()
    {
        var result = _userService.GetUsers();
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public ActionResult<UserDTO> GetUserById(Guid userId)
    {
        var result = _userService.GetUserById(userId);
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<UserDTO> CreateUser(UserWithoutIdDTO user)
    {
        var result = _userService.CreateUser(user);
        return Ok(result);
    }
    [HttpGet("subsidiary/{subsidiaryId}")]
    public async Task<ActionResult<UserDTO>> GetUserBySubsidiaryId(Guid subsidiaryId)
    {
        return Ok(await _userService.GetUsersBySubsidiaryId(subsidiaryId));
    }

    [HttpPut("{userId}")]
    public ActionResult<UserDTO> UpdateUser(Guid userId, UpdateUserDTO user)
    {
        var result = _userService.UpdateUser(userId, user);
        return Ok(result);
    }

    [HttpPost("subsidiary/email")]
    public async Task<ActionResult<UserDTO>> GetUserBySubsidiaryAndEmail(UserBySubsidiaryDTO user)
    {
        return Ok(await _userService.GetUserBySubsidiaryAndEmail(user));
    }
    
    [HttpPost("email")]
    public ActionResult<UserDTO> GetUserByEmail(EmailDTO email)
    {
        return Ok(_userService.GetUserByEmail(email));
    }
    
    [HttpPut("update-users")]
    public ActionResult<List<UserDTO>> UpdateUsers([FromBody] List<UserDTO> users)
    {
        var result = _userService.UpdateUsers(users);
        return Ok(result);
    }

}
