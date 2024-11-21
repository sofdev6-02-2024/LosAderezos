using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenservice _tokenService;

    public UserController(IUserService userService, ITokenservice tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }
    
    [HttpGet]
    public ActionResult<List<UserDTO>> GetAllUsers()
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (!_userService.IsUserOwnerOrHigher(toVerify.UserId) == true)
        {
            return Unauthorized("you are not an owner");
        }
        var result = _userService.GetUsers();
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public ActionResult<UserDTO> GetUserById(Guid userId)
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (!_userService.IsUserAdminOrHigher(toVerify.UserId) == true || userId != toVerify.UserId)
        {
            return Unauthorized("you are not an admin nor owner nor the user you want to get");
        }
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (_userService.IsUserAdminOrHigher(toVerify.UserId) == true)
        {
            return Unauthorized("you are not an admin nor owner");
        }

        return Ok(await _userService.GetUsersBySubsidiaryId(subsidiaryId));
    }

    [HttpPut]
    public ActionResult<UserDTO> UpdateUser(UserDTO user)
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (user.UserId != toVerify.UserId)
        {
            return Unauthorized("you are not the user you want to update");
        }
        
        if (!_userService.IsUserOwnerOrHigher(toVerify.UserId) == true || user.UserId != toVerify.UserId)
        {
            return Unauthorized("you are not an owner nor the user you want to get");
        }
        var result = _userService.UpdateUser(user);
        return Ok(result);
    }

    [HttpPost("subsidiary/email")]
    public async Task<ActionResult<UserDTO>> GetUserBySubsidiaryAndEmail(UserBySubsidiaryDTO user)
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (_userService.IsUserAdminOrHigher(toVerify.UserId) == true)
        {
            return Unauthorized("you are not an admin nor owner");
        }

        return Ok(await _userService.GetUserBySubsidiaryAndEmail(user));
    }
    
    [HttpPost("email")]
    public ActionResult<UserDTO> GetUserByEmail(EmailDTO email)
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (_userService.IsUserAdminOrHigher(toVerify.UserId) == true)
        {
            return Unauthorized("you are not an admin nor owner");
        }

        return Ok(_userService.GetUserByEmail(email));
    }
    
    [HttpPut("update-users")]
    public ActionResult<List<UserDTO>> UpdateUsers([FromBody] List<UserDTO> users)
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
        if (!_tokenService.IsTokenValid(toVerify))
        {
            return Unauthorized("Invalid token");
        }

        if (_userService.IsUserOwnerOrHigher(toVerify.UserId) == true)
        {
            return Unauthorized("you are not an owner");
        }
        var result = _userService.UpdateUsers(users);
        return Ok(result);
    }

    [HttpGet("isAdminOrHigher/{userId}")]
    public ActionResult<bool> GetIsAdminOrHigher(Guid userId)
    {
        return Ok(_userService.IsUserAdminOrHigher(userId));
    }
    
    [HttpGet("isOwnerOrHigher/{userId}")]
    public ActionResult<bool> GetIsOwnerOrHigher(Guid userId)
    {
        return Ok(_userService.IsUserOwnerOrHigher(userId));
    }
}
