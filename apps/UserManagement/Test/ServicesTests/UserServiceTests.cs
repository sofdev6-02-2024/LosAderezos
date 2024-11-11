using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServicesTests;

[TestFixture]
public class UserServiceTests
{
     private Mock<IUserDAO> _userDaoMock;
    private Mock<IMapper> _mapperMock;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _userDaoMock = new Mock<IUserDAO>();
        _mapperMock = new Mock<IMapper>();
        _userService = new UserService(_userDaoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetUsers_ShouldReturnMappedUserDTOList()
    {
        // Arrange
        var users = new List<User> { new User(), new User() };
        var userDtos = new List<UserDTO> { new UserDTO(), new UserDTO() };

        _userDaoMock.Setup(dao => dao.ReadAll()).Returns(users);
        _mapperMock.Setup(m => m.Map<UserDTO>(It.IsAny<User>()))
                   .Returns((User source) => userDtos[users.IndexOf(source)]);

        // Act
        var result = await _userService.GetUsers();

        // Assert
        Assert.That(result.Count, Is.EqualTo(userDtos.Count));
        _userDaoMock.Verify(dao => dao.ReadAll(), Times.Once);
        _mapperMock.Verify(m => m.Map<UserDTO>(It.IsAny<User>()), Times.Exactly(users.Count));
    }

    [Test]
    public async Task GetUserById_ShouldReturnMappedUserDTO()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { UserId = userId };
        var userDto = new UserDTO { UserId = userId };

        _userDaoMock.Setup(dao => dao.Read(userId)).Returns(user);
        _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDto);

        // Act
        var result = await _userService.GetUserById(userId);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.UserId, Is.EqualTo(userDto.UserId));
        _userDaoMock.Verify(dao => dao.Read(userId), Times.Once);
        _mapperMock.Verify(m => m.Map<UserDTO>(user), Times.Once);
    }

    [Test]
    public async Task CreateUser_ShouldReturnMappedUserDTOAfterCreation()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var birthdate = DateTime.Today;
        var userWithoutId = new UserWithoutIdDTO()
        {
            Name = "Test User",
            BirthDate = birthdate,
            Email = "test@test.com",
            PhoneNumber = "123456",
            Rol = "admin",
        };
        var user = new User()
        {
            UserId = guid,
            Name = "Test User",
            BirthDate = birthdate,
            Email = "test@test.com",
            PhoneNumber = "123456",
            Rol = "admin",
        };
        var userDto = new UserDTO()
        {
            UserId = guid,
            Name = "Test User",
            BirthDate = birthdate,
            Email = "test@test.com",
            PhoneNumber = "123456",
            Rol = "admin",
        };

        _mapperMock.Setup(m => m.Map<User>(It.IsAny<(UserWithoutIdDTO, Guid)>())).Returns(user);
        _userDaoMock.Setup(dao => dao.Create(It.IsAny<User>()));
        _userDaoMock.Setup(dao => dao.Read(It.IsAny<Guid>())).Returns(user);
        _mapperMock.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.CreateUser(userWithoutId);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.UserId, Is.EqualTo(userDto.UserId));
    }

    [Test]
    public async Task UpdateUser_ShouldReturnUpdatedUserDTO()
    {
        // Arrange
        var userDto = new UserDTO { UserId = Guid.NewGuid(), Name = "Updated User" };
        var user = new User { UserId = userDto.UserId, Name = "Updated User" };

        _mapperMock.Setup(m => m.Map<User>(userDto)).Returns(user);
        _userDaoMock.Setup(dao => dao.Update(user));
        _userDaoMock.Setup(dao => dao.Read(userDto.UserId)).Returns(user);
        _mapperMock.Setup(m => m.Map<UserDTO>(user)).Returns(userDto);

        // Act
        var result = await _userService.UpdateUser(userDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.UserId, Is.EqualTo(userDto.UserId));
        _mapperMock.Verify(m => m.Map<User>(userDto), Times.Once);
        _userDaoMock.Verify(dao => dao.Update(user), Times.Once);
        _userDaoMock.Verify(dao => dao.Read(userDto.UserId), Times.Once);
        _mapperMock.Verify(m => m.Map<UserDTO>(user), Times.Once);
    }
}
