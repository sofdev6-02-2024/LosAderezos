using Backend.DTOs;
using Backend.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportsController(IReportService reportService): ControllerBase
{
    [HttpPost("/input")]
    public ActionResult<List<InputReportDTO>> PostInput(List<InputReportDTO> inputReport)
    {
        return reportService.GenerateInputReport(inputReport);
    }
    
    
    [HttpPost("/output")]
    public ActionResult<List<OutputReportDTO>> PostOutput(List<OutputReportDTO> outputReport)
    {
        return reportService.GenerateOutputReport(outputReport);
    }
}