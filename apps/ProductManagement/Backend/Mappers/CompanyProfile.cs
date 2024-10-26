using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDTO>();
        CreateMap<CompanyDTO, Company>();
        CreateMap<Company, CompanyWithoutIDDTO>();
        CreateMap< (CompanyWithoutIDDTO, Guid), Company>()
            .ForMember(dest => dest.CompanyId, expression => expression.MapFrom(src => src.Item2));
    }
}