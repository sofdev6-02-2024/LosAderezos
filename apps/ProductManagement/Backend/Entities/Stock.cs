namespace Backend.Entities;

public class Stock
{
    public Guid StockId { get; set; }
    public int Code { get; set; }
    public int Quantity { get; set; }
    
    //Forign Key
    public Guid ProductId { get; set; }
    public Guid SubsidiaryId { get; set; }
}
