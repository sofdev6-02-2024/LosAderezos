using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class SubsidiaryProfile: Profile
{
    protected SubsidiaryProfile()
    {
        CreateMap<Subsidiary, SubsidiaryDTO>();
        CreateMap<SubsidiaryDTO, Subsidiary>();
        CreateMap<(SubsidiaryWithoutDTO, Guid), Subsidiary>();
        CreateMap<Subsidiary, SubsidiaryWithoutDTO>();
    }
}