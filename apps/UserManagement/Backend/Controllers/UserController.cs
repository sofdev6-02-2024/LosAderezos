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
    public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
    {
        var result = await _userService.GetUsers();
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDTO>> GetUserById(Guid userId)
    {
        var result = await _userService.GetUserById(userId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(UserWithoutIdDTO user)
    {
        var result = await _userService.CreateUser(user);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO user)
    {
        var result = await _userService.UpdateUser(user);
        return Ok(result);
    }

    [HttpPost("email")]
    public async Task<ActionResult<UserDTO>> GetUserByEmail(UserBySubsidiaryDTO user)
    {
        return await _userService.GetUserByEmail(user);
    }
}
