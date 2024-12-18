using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;
using Mysqlx.Datatypes;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IUserDAO _userDao;
    private readonly IMapper _mapper;
    private readonly IProductAPIService _productApiService;

    public UserService(IUserDAO userDao, IMapper mapper, IProductAPIService productApiService)
    {
        _userDao = userDao;
        _mapper = mapper;
        _productApiService = productApiService;
    }

    public List<UserDTO> GetUsers()
    {
        var result = _userDao.ReadAll().Select(_mapper.Map<UserDTO>).ToList();
        return result;
    }

    public UserDTO? GetUserById(Guid id)
    {
        var result = _mapper.Map<UserDTO>(_userDao.Read(id));
        return result;
    }

    public async Task<List<UserDTO>> GetUsersBySubsidiaryId(Guid subsidiaryId)
    {
        var subsidiaryUsers = await _productApiService.GetUsersBySubsidiaryId(subsidiaryId);
        List<UserDTO> users = new List<UserDTO>();
        if (subsidiaryUsers == null)
        {
            return users;
        }
        foreach (SubsidiaryUsersDTO subsidiaryUser in subsidiaryUsers)
        {
            var user = _userDao.Read(subsidiaryUser.userId);
            if (user != null)
            {
                users.Add(_mapper.Map<UserDTO>(user));    
            }
        }
        return users;
    }

    public UserDTO? CreateUser(UserWithoutIdDTO user)
    {
        if (_userDao.ReadAll().Any(u => user.Email == u.Email))
        {
            return null;
        }
        Guid id = Guid.NewGuid();
        _userDao.Create(_mapper.Map<User>((user, id)));
        return _mapper.Map<UserDTO>(_userDao.Read(id));
    }

    public UserDTO? UpdateUser(Guid userId, UpdateUserDTO user)
    {
        var oldUser = _userDao.Read(userId);
        _userDao.Update(_mapper.Map<User>((oldUser, user )));
        return _mapper.Map<UserDTO>(_userDao.Read(userId));
    }

    public async Task<UserDTO?> GetUserBySubsidiaryAndEmail(UserBySubsidiaryDTO user)
    {
        var foundUser = _userDao.ReadAll().FirstOrDefault(u => u.Email == user.Email);
        if (foundUser != null)
        {
            List<SubsidiaryUsersDTO>? subsidiaryUsers = await _productApiService.GetUsersBySubsidiaryId(user.SubsidiaryId);
            if (subsidiaryUsers != null)
            {
                List<UserDTO> users = new List<UserDTO>();
                foreach (SubsidiaryUsersDTO subsidiaryUser in subsidiaryUsers)
                {
                    var newUser = GetUserById(subsidiaryUser.userId);
                    if (newUser != null)
                    {
                        users.Add(newUser);
                    }
                    
                }
                if (users.Any(dto => dto.UserId == foundUser.UserId))
                {
                    return _mapper.Map<UserDTO>(_mapper.Map<User>(foundUser));
                }
            }
        }
        return null;
    }

    public UserDTO? GetUserByEmail(EmailDTO email)
    {
        return _mapper.Map<UserDTO>(_userDao.ReadAll().FirstOrDefault(u => u.Email == email.Email));
    }
    
    public List<UserDTO> UpdateUsers(List<UserDTO> users)
    {
        var updatedUsers = new List<UserDTO>();
    
        foreach (var userDto in users)
        {
            var user = _userDao.Read(userDto.UserId);
            if (user != null)
            {
                _userDao.Update(_mapper.Map<User>(userDto));
                var updatedUser = _userDao.Read(userDto.UserId);
                updatedUsers.Add(_mapper.Map<UserDTO>(updatedUser));
            }
        }

        return updatedUsers;
    }

}
