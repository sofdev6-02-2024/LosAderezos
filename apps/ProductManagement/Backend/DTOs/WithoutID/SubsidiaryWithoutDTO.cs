namespace Backend.DTOs.WithoutID;

public class SubsidiaryWithoutDTO
{
    public string Location { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Guid CompanyId { get; set; }
}

