namespace Backend.DTOs.WithoutID;

public class OtherSubsidiariesProductsDTO
{
    public string SubsidiaryName { get; set; } = string.Empty;
    public string SubsidiaryLocation { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
