namespace Backend.DTOs.WithoutID;

public class ProductCategoryListPostDTO
{
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public Guid ProductId { get; set; }
}