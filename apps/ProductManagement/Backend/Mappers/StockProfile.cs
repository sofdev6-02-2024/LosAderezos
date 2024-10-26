using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;

namespace Backend.Mappers;

public class StockProfile : Profile
{
    public StockProfile()
    {
        CreateMap<Stock, StockDTO>();
        CreateMap<StockDTO, Stock>();
        CreateMap<Stock, StockWithoutIDDTO>();
        CreateMap<(StockWithoutIDDTO, Guid), Stock>()
            .ForMember(dest => dest.StockId, expression => expression.MapFrom(src => src.Item2));

    }
}
