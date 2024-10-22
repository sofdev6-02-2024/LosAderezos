namespace ProductManagement.Entities;

public class Subsidiary
{
    public Guid SubsidiaryId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public Location Location { get; set; }
    public List<Stock> Stocks { get; set; }
    public List<Guid> Admins { get; set; }
    public List<Guid> Operators { get; set; }

    public Subsidiary()
    {
        Location = new Location();
        Stocks = new List<Stock>();
        Admins = new List<Guid>();
        Operators = new List<Guid>();
    }
}

public class Location
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Stock
{
    public Guid StockID { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}