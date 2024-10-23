namespace Backend.DTOs.WithID;

public class ProductWithoutIDDTO
{
    public string Name { get; set; }
    public decimal IncomingPrice {get; set;}
    public int Code { get; set; }
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
}