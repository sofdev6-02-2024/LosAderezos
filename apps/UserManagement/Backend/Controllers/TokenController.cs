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
    public Task<ActionResult<UserFullInfoDTO>> PostToken(CreateTokenDTO sessionPostDto)
    {
        if(!_tokenService.IsTokenValid(Guid.Parse(Request.Headers["SessionId"])))
        {
            return Task.FromResult<ActionResult<UserFullInfoDTO>>(Redirect("http://localhost:5173/"));
        }
        var result = _tokenService.PostToken(sessionPostDto);
        return Task.FromResult<ActionResult<UserFullInfoDTO>>(Ok(result));
    }

    [HttpGet("GetCookie/{userId}")]
    public ActionResult<bool> GetCookie(Guid userId)
    {
        var result = _tokenService.GetCookie(userId);
        return Ok(result);
    }

    [HttpPost("RefreshToken")]
    public ActionResult<UserFullInfoDTO> RefreshToken(TokenWithoutIdDTO oldToken)
    {
        var result = _tokenService.RefreshToken(oldToken);
        return Ok(result);
    }

    [HttpGet("GetTokenUser/{userId}")]
    public ActionResult<UserFullInfoDTO> GetTokenUser(Guid userId)
    {
        var result = _tokenService.GetTokenUser(userId);
        return Ok(result);
    }

    [HttpGet("IsTokenValid/{userId}")]
    public ActionResult<bool> IsTokenValid(Guid userId)
    {
        var result = _tokenService.IsTokenValid(userId);
        return Ok(result);
    }
}