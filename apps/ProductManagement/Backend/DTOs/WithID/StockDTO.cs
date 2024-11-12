namespace Backend.DTOs.WithID;

public class StockDTO
{
    public Guid StockId { get; set; }
    public int Code { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal IncomingPrice {get; set;}
    public int ProductCode { get; set; }
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
    public int LowExistence { get; set; }
    public bool Notify  { get; set; }
    public Guid SubsidiaryId { get; set; }
}
