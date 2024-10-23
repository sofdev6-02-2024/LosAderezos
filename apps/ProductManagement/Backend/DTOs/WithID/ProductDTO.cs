namespace Backend.DTOs.WithID;

public class ProductDTO
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal IncomingPrice {get; set;}
    public int Code { get; set; }
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
}