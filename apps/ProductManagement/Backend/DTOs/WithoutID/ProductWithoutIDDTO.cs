namespace Backend.DTOs.WithID;

public class ProductWithoutIDDTO
{
    public string Name { get; set; }  = string.Empty;
    public string Code { get; set; } = string.Empty;
    public decimal IncomingPrice {get; set;}
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
    public int LowExistence { get; set; }
    public bool Notify { get; set; }
}