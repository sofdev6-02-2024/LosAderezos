namespace ProductManagement.Entities;

public class Subsidiary
{
   public Guid SubsidiaryId { get; set; }
   public decimal Latitude { get; set; }
   public decimal Longitude { get; set; }
   public string Name { get; set; }
   public string Type { get; set; }
   
   //Foreign Key
   public Guid CompanyId { get; set; }
}
