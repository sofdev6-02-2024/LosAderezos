using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyDAO _companyDao;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyDAO companyDao, IMapper mapper)
    {
        _companyDao = companyDao;
        _mapper = mapper;
    }

    public List<CompanyDTO> GetCompanies()
    {
        return _companyDao.ReadAll().Select(company => _mapper.Map<CompanyDTO>(company)).ToList();
    }

    public CompanyDTO? GetCompanyById(Guid id)
    {
        return _mapper.Map<CompanyDTO>(_companyDao.Read(id));
    }

    public CompanyDTO? CreateCompany(CompanyWithoutIDDTO company)
    {
        Guid guid = Guid.NewGuid();
        _companyDao.Create(_mapper.Map<Company>((company, guid)));
        return _mapper.Map<CompanyDTO>(_companyDao.Read(guid));
    }

    public CompanyDTO? UpdateCompany(CompanyDTO company)
    {
        _companyDao.Update(_mapper.Map<Company>(company));
        return _mapper.Map<CompanyDTO>(_companyDao.Read(company.CompanyId));
    }
}
