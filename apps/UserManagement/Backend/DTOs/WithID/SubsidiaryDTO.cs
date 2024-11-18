namespace Backend.DTOs.WithID;

public class SubsidiaryDTO
{
    public Guid subsidiaryId { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
    public string name { get; set; }  = string.Empty;
    public string type { get; set; }  = string.Empty;
    public Guid companyId { get; set; }
}
