using Backend.DTOs.WithID;

namespace Backend.Services.ServiceInterfaces;

public interface IProductAPIService
{
    public Task<List<SubsidiaryUsersDTO>?> GetUsersBySubsidiaryId(Guid id);
    public Task<List<SubsidiaryUsersDTO>?> GetUsersByCompanyId(Guid id);
    public Task<Guid?> GetCompanyIdByUserId(Guid userId);
    public Task<List<Guid>?> GetSubsidiariesIdsByUserId(Guid userId);
}
