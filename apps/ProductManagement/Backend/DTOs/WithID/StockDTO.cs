namespace Backend.DTOs.WithID;

public class StockDTO
{
    public Guid StockId { get; set; }
    public int Code { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Guid SubsidiaryId { get; set; }
}