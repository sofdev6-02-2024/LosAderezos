using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface ISubsidiaryService
{
    public Task<List<SubsidiaryDTO>> GetSubsidiaries();
    public Task<SubsidiaryDTO> GetSubsidiaryById(Guid id);
    public Task<SubsidiaryDTO> CreateSubsidiary(SubsidiaryWithoutDTO subsidiary);
    public Task<SubsidiaryDTO> UpdateSubsidiary(SubsidiaryDTO subsidiary);
    
}
