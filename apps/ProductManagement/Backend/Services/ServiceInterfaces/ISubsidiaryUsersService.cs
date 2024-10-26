using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface ISubsidiaryUsersService
{
    public Task<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersByUserId(Guid userId);
    public Task<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId);
    public Task<SubsidiaryUsersDTO> GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers);
    public Task<SubsidiaryUsersDTO> CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers);
    public Task<bool> DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers);
}