using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class SubsidiaryUsersService : ISubsidiaryUsersService
{
    private readonly ISubsidiaryUsersDAO _subsidiaryUsersDao;
    private readonly IMapper _mapper;

    public SubsidiaryUsersService(ISubsidiaryUsersDAO subsidiaryUsersDao, IMapper mapper)
    {
        _subsidiaryUsersDao = subsidiaryUsersDao;
        _mapper = mapper;
    }

    public async Task<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersByUserId(Guid userId)
    {
        return _subsidiaryUsersDao.GetSubsidiaryUsersByUserId(userId).Select(u => _mapper.Map<SubsidiaryUsersDTO>(u)).ToList();
    }

    public async Task<List<SubsidiaryUsersDTO>> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId)
    {
        return _subsidiaryUsersDao.GetSubsidiaryUsersBySubsidiaryId(subsidiaryId).Select(u => _mapper.Map<SubsidiaryUsersDTO>(u)).ToList();
    }

    public async Task<SubsidiaryUsersDTO> GetSubsidiaryUsersByBothIds(SubsidiaryUsersDTO subsidiaryUsers)
    {
        return _mapper.Map<SubsidiaryUsersDTO>(_subsidiaryUsersDao.Read(subsidiaryUsers.SubsidiaryId, subsidiaryUsers.UserId));
    }

    public async Task<SubsidiaryUsersDTO> CreateSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        _subsidiaryUsersDao.Create(_mapper.Map<SubsidiaryUsers>(subsidiaryUsers));
        return _mapper.Map<SubsidiaryUsersDTO>(_subsidiaryUsersDao.Read(subsidiaryUsers.SubsidiaryId, subsidiaryUsers.UserId));
    }

    public async Task<bool> DeleteSubsidiaryUsers(SubsidiaryUsersDTO subsidiaryUsers)
    {
        return _subsidiaryUsersDao.Delete(subsidiaryUsers.SubsidiaryId, subsidiaryUsers.UserId);
    }
}
