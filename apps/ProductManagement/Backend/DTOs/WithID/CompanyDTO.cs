namespace Backend.DTOs.WithID;

public class CompanyDTO
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
}
