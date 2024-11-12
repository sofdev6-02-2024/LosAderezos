using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Mappers;

public class SubsidiaryUsersProfile : Profile
{
    public SubsidiaryUsersProfile()
    {
        CreateMap<SubsidiaryUsersDTO, SubsidiaryUsers>()
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId))
            .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId));
        CreateMap<SubsidiaryUsers, SubsidiaryUsersDTO>()
            .ForMember(dst => dst.SubsidiaryId, opt => opt.MapFrom(src => src.SubsidiaryId))
            .ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId));
    }
}
