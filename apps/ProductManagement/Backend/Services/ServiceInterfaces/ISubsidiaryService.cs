using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface ISubsidiaryService
{
    public Task<SubsidiaryDTO> GetSubsidiaryById(Guid id);
    public Task<List<SubsidiaryDTO>> GetAllSubsidiariesByCompanyId(Guid companyId);
    public Task<SubsidiaryDTO> CreateSubsidiary(SubsidiaryWithoutDTO subsidiary);
    public Task<SubsidiaryDTO> UpdateSubsidiary(SubsidiaryDTO subsidiary);
    
}