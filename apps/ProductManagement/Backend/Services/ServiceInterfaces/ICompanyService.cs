using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface ICompanyService
{
    public Task<List<CompanyDTO>> GetCompanies();
    public Task<CompanyDTO?> GetCompanyById(Guid id);
    public Task<CompanyDTO?> CreateCompany(CompanyWithoutIDDTO company);
    public Task<CompanyDTO?> UpdateCompany(CompanyDTO company);
}