
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public class TokenService: ITokenservice
{
    private readonly ISessionTokenDAO _sessionTokenDao;
    private readonly IUserDAO _userDao;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly TimeSpan ExpirationTime = new TimeSpan(0, 30, 1);


    public TokenService(ISessionTokenDAO sessionTokenDao, IUserDAO userDao, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _sessionTokenDao = sessionTokenDao;
        _userDao = userDao;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public UserFullInfoDTO PostToken(CreateTokenDTO sessionPostDto)
    {
        var user = _userDao.ReadAll().Where(u => u.Email == sessionPostDto.Email).First();
        var token = _mapper.Map<SessionToken>((sessionPostDto.Token, user.UserId, DateTime.Now));
        _sessionTokenDao.Create(token);
        return _mapper.Map<UserFullInfoDTO>((token, user));

    }

    public bool GetCookie(Guid userId)
    {
        
        SessionToken? session = _sessionTokenDao.ReadAll().FirstOrDefault(u => u.UserId == userId);
        if (session == null)
        {
            return false;
        }
        User? user = _userDao.Read(userId);
        if (user == null)
        {
            return false;
        }
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(session.Token + "XD"));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("UserEmail", user.Email),
            new Claim("UserRol", user.Rol),
            new Claim("UserBirthDate", user.BirthDate.ToString("dd-mm-yyyy")),
            new Claim("UserPhoneNumber", user.PhoneNumber),
            new Claim("UserName", user.Name),
            new Claim( "Token", session.Token),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var cookieOptions = new CookieOptions
        {
            HttpOnly = false, 
            Secure = true,
            Expires = DateTime.UtcNow.AddDays(1),
            SameSite = SameSiteMode.None
        };

        _httpContextAccessor.HttpContext?.Response.Cookies.Append("session", tokenHandler.WriteToken(token), cookieOptions);
        return true;
    }

    public UserFullInfoDTO RefreshToken(TokenWithoutIdDTO oldToken)
    {
        var token = _mapper.Map<SessionToken>(oldToken);
        DateTime createdAt = DateTime.Now;
        _sessionTokenDao.Update(new SessionToken()
        {
            UserId = token.UserId,
            Token = token.Token,
            Time = createdAt,
            
        });
        var user = _userDao.Read(oldToken.UserId);
        return _mapper.Map<UserFullInfoDTO>((token, user));
        
        
    }

    public UserFullInfoDTO GetTokenUser(Guid userId)
    {
        var token = _sessionTokenDao.ReadAll().FirstOrDefault(u => u.UserId == userId); 
        var user = _userDao.Read(userId);
        return _mapper.Map<UserFullInfoDTO>((token, user));
    }

    public bool IsTokenValid(Guid userId)
    {
        var token = _sessionTokenDao.ReadAll().FirstOrDefault(u => u.UserId == userId);
        if (token == null)
        {
            return false;
        }
        return (DateTime.Now - token.Time)  < ExpirationTime;

    }
}
