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
        CreateMap<StockWithoutIDDTO, Stock>()
            .ForMember(dest => dest.StockId,
                opt => opt.MapFrom(src => Guid.NewGuid()));
    }
}
