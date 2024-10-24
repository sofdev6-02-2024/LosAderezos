namespace Backend.DTOs.WithoutID;

public class SubsidiaryWithoutDTO
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
}

