namespace Backend.DTOs.WithoutID;

public class SubsidiaryWithoutDTO
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Guid CompanyId { get; set; }
}
