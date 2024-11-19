using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface ISubsidiaryUsersService
{
    public List<SubsidiaryUsersDTO> GetSubsidiaryUsersByUserId(Guid userId);
    public List<SubsidiaryUsersDTO> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId);
    public SubsidiaryUsersDTO GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers);
    public SubsidiaryUsersDTO CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers);
    public bool DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers);
}
