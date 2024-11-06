using System.Text.Json;
using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    private readonly IUserDAO _userDao;
    private readonly IMapper _mapper;

    public UserService(IUserDAO userDao, IMapper mapper, HttpClient httpClient)
    {
        _userDao = userDao;
        _mapper = mapper;
        _httpClient = httpClient;
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        var result = _userDao.ReadAll().Select(_mapper.Map<UserDTO>).ToList();
        return result;
    }

    public async Task<UserDTO?> GetUserById(Guid id)
    {
        var result = _mapper.Map<UserDTO>(_userDao.Read(id));
        return result;
    }

    public async Task<UserDTO?> CreateUser(UserWithoutIdDTO user)
    {
        Guid id = Guid.NewGuid();
        _userDao.Create(_mapper.Map<User>((user, id)));
        return _mapper.Map<UserDTO>(_userDao.Read(id));
    }

    public async Task<UserDTO?> UpdateUser(UserDTO user)
    {
        _userDao.Update(_mapper.Map<User>(user));
        return _mapper.Map<UserDTO>(_userDao.Read(user.UserId));
    }

    public async Task<UserDTO?> GetUserByEmail(UserBySubsidiaryDTO user)
    {
        var foundUser = _userDao.ReadAll().First(u => u.Email == user.Email);
        if (foundUser != null)
        {
            string url = $"http://ProductManagementService/SubsidiaryUsers/subsidiary/{user.SubsidiaryId}";    
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var persons = JsonSerializer.Deserialize<List<UserDTO>>(content);

            if (persons.Any(dto => dto.UserId == foundUser.UserId))
            {
                return _mapper.Map<UserDTO>(_mapper.Map<User>(foundUser));
            }    
        }
        return null;
    }
}
