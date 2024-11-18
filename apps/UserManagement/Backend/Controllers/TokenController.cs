using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase 
{
    private readonly ITokenservice _tokenService;

    public TokenController(ITokenservice tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public ActionResult<UserFullInfoDTO> PostToken(CreateTokenDTO sessionPostDto)
    {
        var result = _tokenService.PostToken(sessionPostDto);
        return Ok(result);
    }

    [HttpGet("GetCookie/{userId}")]
    public ActionResult<bool> GetCookie(Guid userId)
    {
        var result = _tokenService.GetCookie(userId);
        if (!result)
            return Redirect("http://localhost:5173/");
        return Redirect("http://localhost:5173/store_menu");
    }

    [HttpPost("RefreshToken")]
    public ActionResult<UserFullInfoDTO> RefreshToken(TokenWithoutIdDTO oldToken)
    {
        var result = _tokenService.RefreshToken(oldToken);
        return Ok(result);
    }

    [HttpGet("GetTokenUser/{userId}")]
    public ActionResult<UserFullInfoDTO?> GetTokenUser(Guid userId)
    {
        var result = _tokenService.GetTokenUser(userId);
        return Ok(result);
    }

    [HttpPost("IsTokenValid")]
    public ActionResult<bool> IsTokenValid(ValidateTokenDTO token)
    {
        var result = _tokenService.IsTokenValid(token);
        return Ok(result);
    }
}
