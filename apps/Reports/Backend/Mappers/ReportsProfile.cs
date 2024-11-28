using AutoMapper;
using Backend.DTOs;
using Entities;

namespace Backend.Mappers;

public class ReportsProfile: Profile
{
    public ReportsProfile()
    {
        CreateMap<ProductInput, InputReportDTO>()
            .ReverseMap();
        CreateMap<ProductOutput, OutputReportDTO>()
            .ReverseMap();
    }
}