using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IUserService
{
    public List<UserDTO> GetUsers();
    public UserDTO? GetUserById(Guid id);
    public UserDTO? CreateUser(UserWithoutIdDTO user);
    public UserDTO? UpdateUser(UserDTO user);
    public Task<UserDTO?> GetUserByEmail(UserBySubsidiaryDTO user);
}
