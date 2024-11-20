using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface ICompanyService
{
    public List<CompanyDTO> GetCompanies();
    public CompanyDTO? GetCompanyById(Guid id);
    public CompanyDTO? CreateCompany(CompanyWithoutIDDTO company);
    public CompanyDTO? UpdateCompany(CompanyDTO company);
}
