using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface IUserService
{
    public List<UserDTO> GetUsers();
    public UserDTO? GetUserById(Guid id);
    public Task<List<UserDTO>> GetUsersBySubsidiaryId(Guid subsidiaryId);
    public UserDTO? CreateUser(UserWithoutIdDTO user);
    public UserDTO? UpdateUser(Guid userId, UpdateUserDTO user);
    public Task<UserDTO?> GetUserBySubsidiaryAndEmail(UserBySubsidiaryDTO user);
    public UserDTO? GetUserByEmail(EmailDTO email);
    public List<UserDTO> UpdateUsers(List<UserDTO> users);
}
