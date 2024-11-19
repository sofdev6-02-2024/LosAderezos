using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface ISubsidiaryService
{
    public List<SubsidiaryDTO> GetSubsidiaries();
    public SubsidiaryDTO? GetSubsidiaryById(Guid id);
    public List<SubsidiaryDTO> GetSubsidiariesByCompanyId(Guid id);
    public SubsidiaryDTO CreateSubsidiary(SubsidiaryWithoutDTO subsidiary);
    public SubsidiaryDTO UpdateSubsidiary(SubsidiaryDTO subsidiary);
    
}
