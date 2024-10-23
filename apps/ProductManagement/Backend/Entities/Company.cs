namespace Backend.Entities;

public class Company
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    //Foreign Key
    public Guid UserId { get; set; }
}
