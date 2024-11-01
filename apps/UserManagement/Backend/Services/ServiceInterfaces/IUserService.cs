using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IUserService
{
    public Task<List<UserDTO>> GetUsers();
    public Task<UserDTO?> GetUserById(Guid id);
    public Task<UserDTO?> CreateUser(UserWithoutIdDTO user);
    public Task<UserDTO?> UpdateUser(UserDTO user);
}
