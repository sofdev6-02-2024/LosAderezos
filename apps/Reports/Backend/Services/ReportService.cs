using AutoMapper;
using Backend.DTOs;
using Backend.Services.interfaces;
using DB;
using Entities;

namespace Backend.Services;

public class ReportService(IProductInputDAO inputDao, IProductOutputDAO outputDao, IMapper mapper): IReportService
{
    public List<InputReportDTO> GenerateInputReport(List<InputReportDTO> inputReport)
    {
        foreach (var input in inputReport)
        {
            inputDao.Write(mapper.Map<ProductInput>(input));
        }
        return inputReport;
    }

    public List<OutputReportDTO> GenerateOutputReport(List<OutputReportDTO> outputReport)
    {
        foreach (var output in outputReport)
        {
            outputDao.Write(mapper.Map<ProductOutput>(output));
        }
        return outputReport;
    }
}
