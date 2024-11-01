using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class SubsidiaryProfile: Profile
{
    public SubsidiaryProfile()
    {
        CreateMap<Subsidiary, SubsidiaryDTO>();
        CreateMap<SubsidiaryDTO, Subsidiary>();
        CreateMap<(SubsidiaryWithoutDTO, Guid), Subsidiary>()
            .ForMember(dest => dest.SubsidiaryId, expression => expression.MapFrom(src => src.Item2));
        CreateMap<Subsidiary, SubsidiaryWithoutDTO>();
    }
}
