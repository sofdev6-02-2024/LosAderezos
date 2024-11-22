namespace Backend.DTOs.WithID;

public class StockFullInfoDTO
{
    public Guid StockId { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal IncomingPrice {get; set;}
    public string ProductCode { get; set; } = string.Empty;
    public decimal SellPrice {get; set;}
    public Guid CompanyId { get; set; }
    public int LowExistence { get; set; }
    public bool Notify  { get; set; }
    public Guid SubsidiaryId { get; set; }
    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
}
