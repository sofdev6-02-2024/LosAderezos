namespace Backend.Entities;

public class Subsidiary
{
   public Guid SubsidiaryId { get; set; }
   public decimal Latitude { get; set; }
   public decimal Longitude { get; set; }
   public string Name { get; set; } = string.Empty;
   public string Type { get; set; } = string.Empty;
   
   //Foreign Key
   public Guid CompanyId { get; set; }
}
