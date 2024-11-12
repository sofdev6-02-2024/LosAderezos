using AutoMapper;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services;
using DB;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Test.ServicesTests;
[TestFixture]
public class TokenServiceTests
{
    private Mock<ISessionTokenDAO> _sessionTokenDaoMock;
    private Mock<IUserDAO> _userDaoMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IHttpContextAccessor> _httpContextAccessorMock;
    private TokenService _tokenService;
    private User _testUser;
    private SessionToken _testToken;

    [SetUp]
    public void SetUp()
    {
        _sessionTokenDaoMock = new Mock<ISessionTokenDAO>();
        _userDaoMock = new Mock<IUserDAO>();
        _mapperMock = new Mock<IMapper>();
        _httpContextAccessorMock = new Mock<IHttpContextAccessor>();

        _tokenService = new TokenService(
            _sessionTokenDaoMock.Object,
            _userDaoMock.Object,
            _mapperMock.Object,
            _httpContextAccessorMock.Object
        );

        _testUser = new User
        {
            UserId = Guid.NewGuid(),
            Name = "John Doe",
            Email = "john.doe@example.com",
            Rol = "User",
            PhoneNumber = "1234567890",
            BirthDate = new DateTime(1990, 1, 1)
        };

        _testToken = new SessionToken
        {
            UserId = _testUser.UserId,
            Token = "qwertyuiopasdfghjklñzxcvbnmasdfghjklñ",
            Time = DateTime.Now
        };
    }

    [Test]
    public void PostToken_ShouldCreateTokenAndReturnUserInfo()
    {
        // Arrange
        var createTokenDto = new CreateTokenDTO { Email = _testUser.Email, Token = "sampleToken" };
        _userDaoMock.Setup(dao => dao.ReadAll()).Returns(new List<User> { _testUser });
        _mapperMock.Setup(m => m.Map<SessionToken>(It.IsAny<(string, Guid, DateTime)>())).Returns(_testToken);
        _mapperMock.Setup(m => m.Map<UserFullInfoDTO>(It.IsAny<(SessionToken, User)>())).Returns(new UserFullInfoDTO());

        // Act
        var result = _tokenService.PostToken(createTokenDto);

        // Assert
        Assert.IsNotNull(result);
        _sessionTokenDaoMock.Verify(dao => dao.Create(_testToken), Times.Once);
    }

    [Test]
    public void GetCookie_ShouldReturnTrueAndSetCookie_WhenTokenAndUserExist()
    {
        // Arrange
        _sessionTokenDaoMock.Setup(dao => dao.ReadAll()).Returns(new List<SessionToken> { _testToken });
        _userDaoMock.Setup(dao => dao.Read(_testUser.UserId)).Returns(_testUser);
        var responseCookiesMock = new Mock<IResponseCookies>();
        var httpResponseMock = new Mock<HttpResponse>();
        httpResponseMock.Setup(response => response.Cookies).Returns(responseCookiesMock.Object);
        var httpContextMock = new Mock<HttpContext>();
        httpContextMock.Setup(context => context.Response).Returns(httpResponseMock.Object);
        _httpContextAccessorMock.Setup(accessor => accessor.HttpContext).Returns(httpContextMock.Object);

        // Act
        var result = _tokenService.GetCookie(_testUser.UserId);

        // Assert
        Assert.IsTrue(result);
        responseCookiesMock.Verify(cookies => cookies.Append(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CookieOptions>()), Times.Once);
    }

    [Test]
    public void RefreshToken_ShouldUpdateTokenAndReturnUserInfo()
    {
        // Arrange
        var oldTokenDto = new TokenWithoutIdDTO { UserId = _testUser.UserId, Token = "newToken" };
        var updatedToken = new SessionToken { UserId = _testUser.UserId, Token = "newToken", Time = DateTime.Now };
        _mapperMock.Setup(m => m.Map<SessionToken>(oldTokenDto)).Returns(updatedToken);
        _userDaoMock.Setup(dao => dao.Read(_testUser.UserId)).Returns(_testUser);
        _mapperMock.Setup(m => m.Map<UserFullInfoDTO>(It.IsAny<(SessionToken, User)>())).Returns(new UserFullInfoDTO());

        // Act
        var result = _tokenService.RefreshToken(oldTokenDto);

        // Assert
        Assert.IsNotNull(result);
        _sessionTokenDaoMock.Verify(dao => dao.Update(It.IsAny<SessionToken>()), Times.Once);
    }

    [Test]
    public void GetTokenUser_ShouldReturnUserInfo_WhenTokenExists()
    {
        // Arrange
        _sessionTokenDaoMock.Setup(dao => dao.ReadAll()).Returns(new List<SessionToken> { _testToken });
        _userDaoMock.Setup(dao => dao.Read(_testUser.UserId)).Returns(_testUser);
        _mapperMock.Setup(m => m.Map<UserFullInfoDTO>(It.IsAny<(SessionToken, User)>())).Returns(new UserFullInfoDTO());

        // Act
        var result = _tokenService.GetTokenUser(_testUser.UserId);

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void IsTokenValid_ShouldReturnTrue_WhenTokenIsValid()
    {
        // Arrange
        _sessionTokenDaoMock.Setup(dao => dao.ReadAll()).Returns(new List<SessionToken> { _testToken });

        // Act
        var result = _tokenService.IsTokenValid(_testUser.UserId);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsTokenValid_ShouldReturnFalse_WhenTokenIsExpired()
    {
        // Arrange
        var expiredToken = new SessionToken { UserId = _testUser.UserId, Token = "expiredToken", Time = DateTime.Now - TimeSpan.FromHours(1) };
        _sessionTokenDaoMock.Setup(dao => dao.ReadAll()).Returns(new List<SessionToken> { expiredToken });

        // Act
        var result = _tokenService.IsTokenValid(_testUser.UserId);

        // Assert
        Assert.IsFalse(result);
    }
}
