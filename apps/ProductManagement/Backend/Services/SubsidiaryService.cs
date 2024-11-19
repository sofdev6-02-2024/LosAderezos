using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class SubsidiaryService : ISubsidiaryService
{
    private readonly ISubsidiaryDAO _subsidiaryDao;
    private readonly IMapper _mapper;

    public SubsidiaryService(ISubsidiaryDAO subsidiaryDao, IMapper mapper)
    {
        _subsidiaryDao = subsidiaryDao;
        _mapper = mapper;
    }

    public List<SubsidiaryDTO> GetSubsidiaries()
    {
        return _subsidiaryDao.ReadAll().Select(_mapper.Map<SubsidiaryDTO>).ToList();
    }

    public SubsidiaryDTO? GetSubsidiaryById(Guid id)
    {
        return _mapper.Map<SubsidiaryDTO>(_subsidiaryDao.Read(id));
    }

    public List<SubsidiaryDTO> GetSubsidiariesByCompanyId(Guid id)
    {
        var subsidiaries = _subsidiaryDao.ReadAll().Where(s => s.CompanyId == id)
            .Select(s => _mapper.Map<SubsidiaryDTO>(s)).ToList();
        return subsidiaries;
    }

    public SubsidiaryDTO CreateSubsidiary(SubsidiaryWithoutDTO subsidiary)
    {
        
        Guid guid = Guid.NewGuid();
        _subsidiaryDao.Create(_mapper.Map<Subsidiary>((subsidiary, guid)));
        return _mapper.Map<SubsidiaryDTO>(_subsidiaryDao.Read(guid));
    }

    public SubsidiaryDTO UpdateSubsidiary(SubsidiaryDTO subsidiary)
    {
        _subsidiaryDao.Update(_mapper.Map<Subsidiary>(subsidiary));
        return _mapper.Map<SubsidiaryDTO>(_subsidiaryDao.Read(subsidiary.SubsidiaryId));
    }
}
