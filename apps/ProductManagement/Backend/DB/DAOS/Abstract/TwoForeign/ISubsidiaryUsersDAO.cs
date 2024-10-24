using Backend.Entities;

namespace DB;

public interface ISubsidiaryUsersDAO : ITwoForeignDAO<SubsidiaryUsers>
{
    List<SubsidiaryUsers> GetSubsidiaryUsersByUserId(Guid userId);
    List<SubsidiaryUsers> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId);
}
