namespace Backend.Entities;

public class Subsidiary
{
   public Guid SubsidiaryId { get; set; }
   public string Location { get; set; } = string.Empty;
   public string Name { get; set; } = string.Empty;
   public string Type { get; set; } = string.Empty;
   
   //Foreign Key
   public Guid CompanyId { get; set; }
}
