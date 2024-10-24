namespace Backend.DTOs.WithoutID;

public class CompanyWithoutIDDTO
{
    public string Name { get; set; }  = string.Empty;
    public Guid UserId { get; set; }
}
