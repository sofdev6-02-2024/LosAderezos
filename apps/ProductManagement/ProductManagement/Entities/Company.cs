namespace ProductManagement.Entities;

public class Company
{
    public Guid CompanyID { get; set; }
    public string Name { get; set; }
    public List<Guid> Subsidiaries { get; set; }
    public string Partner { get; set; }
    public List<Guid> Products { get; set; }

    public Company()
    {
        Subsidiaries = new List<Guid>();
        Products = new List<Guid>();
    }
}