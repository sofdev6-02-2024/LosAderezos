namespace ProductManagement.Entities;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal IncomingPrice {get; set;}
    public int Code { get; set; }
    public decimal SellPrice {get; set;}
    
    //Foreign Key
    public Guid CompanyId { get; set; }
}
