using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Backend.DTOs.WithID;
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
    private readonly IProductAPIService _productApiService;



    public TokenService(ISessionTokenDAO sessionTokenDao, IUserDAO userDao, IMapper mapper, IHttpContextAccessor httpContextAccessor, IProductAPIService productApiService)
    {
        _sessionTokenDao = sessionTokenDao;
        _userDao = userDao;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _productApiService = productApiService;
    }

    public UserFullInfoDTO? PostToken(CreateTokenDTO sessionPostDto)
    {
        var user = _userDao.ReadAll().Where(u => u.Email == sessionPostDto.Email).FirstOrDefault();
        if (user == null)
        {
            _userDao.Create(new User()
            {
                BirthDate = new DateTime(2000, 8, 20),
                Email = sessionPostDto.Email,
                Name = "usuario nuevo",
                PhoneNumber = string.Empty,
                Rol = "default",
                UserId = Guid.NewGuid(),
            });
        }
        user = _userDao.ReadAll().Where(u => u.Email == sessionPostDto.Email).FirstOrDefault();
        if (user == null)
        {
            return null;
        }
        var token = _mapper.Map<SessionToken>((sessionPostDto.Token, user.UserId, DateTime.Now));
        _sessionTokenDao.Create(token);
        return _mapper.Map<UserFullInfoDTO>((token, user));

    }

    public bool GetCookie(Guid userId)
    {

        SessionToken? session = _sessionTokenDao.Read(userId);
        if (session == null)
        {
            Console.WriteLine("session not found");
            return false;
        }
        
        User? user = _userDao.Read(userId);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return false;
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(session.Token));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var subsIds = _productApiService.GetSubsidiariesIdsByUserId(user.UserId).Result?.Select(sub => sub.ToString()).ToList();
        var subsString = string.Empty;
        if (subsIds != null)
        {
            subsString = string.Join(',', subsIds);
        }
            

        string? companyId = _productApiService.GetCompanyIdByUserId(user.UserId).Result?.ToString();

        var claims = new[]
        {
            new Claim("userId", user.UserId.ToString()),
            new Claim("UserEmail", user.Email),
            new Claim("UserRol", user.Rol),
            new Claim("UserBirthDate", user.BirthDate.ToString("yyyy-MM-dd")),
            new Claim("UserPhoneNumber", user.PhoneNumber),
            new Claim("UserName", user.Name),
            new Claim("Token", session.Token),
            new Claim("subsidiaryId", subsString),
            new Claim("companyId", companyId ?? string.Empty)
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

    public UserFullInfoDTO? GetTokenUser(Guid userId)
    {
        SessionToken? token = _sessionTokenDao.Read(userId);
        if (token == null)
        {
            return null;
        }
        var user = _userDao.Read(userId);
        return _mapper.Map<UserFullInfoDTO>((token, user));
    }

    public bool IsTokenValid(ValidateTokenDTO token)
    {
        SessionToken? userToken = _sessionTokenDao.Read(token.UserId);
        if (userToken == null)
        {
            return false;
        }
        return DateTime.Now - userToken.Time  < ExpirationTime && userToken.Token == token.Token;
    }
    
    public bool UserBelongsToCompany(Guid userId)
    {
        string? companyId = _productApiService.GetCompanyIdByUserId(userId).Result?.ToString();
        return !string.IsNullOrEmpty(companyId);
    }
}
