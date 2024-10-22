namespace ProductManagement.Entities;

public class Product
{
    public Guid ProductID { get; set; }
    public string Name { get; set; }
    public List<string> Categories { get; set; }
}