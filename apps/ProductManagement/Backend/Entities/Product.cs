namespace Backend.Entities;

public class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal IncomingPrice {get; set;}
    public int Code { get; set; }
    public decimal SellPrice {get; set;}
    public int LowExistence { get; set; }
    public bool Notify { get; set; }
    
    //Foreign Key
    public Guid CompanyId { get; set; }
}
