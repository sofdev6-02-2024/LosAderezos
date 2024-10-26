using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class SubsidiaryUsersProfile : Profile
{
    public SubsidiaryUsersProfile()
    {
        CreateMap<SubsidiaryUsersDTO, SubsidiaryUsers>();
        CreateMap<SubsidiaryUsers, SubsidiaryUsersDTO>();
    }
}