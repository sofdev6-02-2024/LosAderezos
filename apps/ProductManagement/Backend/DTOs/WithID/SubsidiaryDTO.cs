namespace Backend.DTOs.WithID;

public class SubsidiaryDTO
{
    public Guid SubsidiaryId { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Name { get; set; }  = string.Empty;
    public string Type { get; set; }  = string.Empty;
    public Guid CompanyId { get; set; }
}
