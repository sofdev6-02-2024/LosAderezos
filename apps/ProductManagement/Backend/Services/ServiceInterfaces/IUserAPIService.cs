using Backend.DTOs.WithID;

namespace Backend.Services.ServiceInterfaces;

public interface IUserAPIService
{
    
    public Task<bool?> IsUserAdminOrHigher(Guid userId);
    public Task<bool?> IsUserOwnerOrHigher(Guid userId);
    public Task<bool> IsTokenValid(ValidateTokenDTO token);
}
