namespace ProductManagement.Entities;

public class Company
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    
    //Foreign Key
    public Guid UserId { get; set; }
}
