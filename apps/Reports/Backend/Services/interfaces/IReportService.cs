using Backend.DTOs;

namespace Backend.Services.interfaces;

public interface IReportService
{
    List<InputReportDTO> GenerateInputReport(List<InputReportDTO> inputReport);
    List<OutputReportDTO> GenerateOutputReport(List<OutputReportDTO> outputReport);
}