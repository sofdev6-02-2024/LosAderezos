namespace Backend.DTOs.WithoutID;

public class StockWithoutIDDTO
{
    public int Code { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public Guid SubsidiaryId { get; set; }
}
