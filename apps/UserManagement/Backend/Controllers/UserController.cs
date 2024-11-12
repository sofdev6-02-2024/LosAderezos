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

    [HttpPut]
    public ActionResult<UserDTO> UpdateUser(UserDTO user)
    {
        var result = _userService.UpdateUser(user);
        return Ok(result);
    }

    [HttpPost("email")]
    public async Task<ActionResult<UserDTO>> GetUserByEmail(UserBySubsidiaryDTO user)
    {
        return Ok(await _userService.GetUserByEmail(user));
    }
}
