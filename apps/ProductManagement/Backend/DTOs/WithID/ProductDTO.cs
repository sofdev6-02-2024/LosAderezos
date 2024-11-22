namespace Backend.DTOs.WithID;

public class ProductDTO
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal IncomingPrice {get; set;}
    public string Code { get; set; }
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
    public int LowExistence { get; set; }
    public bool Notify  { get; set; }
}
