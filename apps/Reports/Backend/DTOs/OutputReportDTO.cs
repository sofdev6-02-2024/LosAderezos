namespace Backend.DTOs;

public class OutputReportDTO
{
    public DateTime Time                { get; set; }
    public int      Quantity            { get; set; }
    public double   SellingPrice        { get; set; }
    public string   ProductName         { get; set; }   = string.Empty;
    public string   Code                { get; set; }   = string.Empty;
    public string   SubsidiaryId        { get; set; }   = string.Empty;
    public string   SubsidiaryUbication { get; set; }   = string.Empty;
    public string   UserEmail           { get; set; }   = string.Empty;
    public string   UserName            { get; set; }   = string.Empty;
    public string   UserRol             { get; set; }   = string.Empty;
    public string   UserPhoneNumber     { get; set; }   = string.Empty;
}