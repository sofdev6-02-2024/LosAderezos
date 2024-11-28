using InfluxDB.Client.Core;

namespace Entities;

[Measurement("ProductOutput")]
public class ProductOutput
{
    [Column(IsTimestamp = true)]                    public DateTime Time                { get; set; }
    [Column("Quantity")]                            public int      Quantity            { get; set; }
    [Column("SellingPrice")]                        public double   SellingPrice        { get; set; }
    [Column("ProductName", IsTag = true)]           public string   ProductName         { get; set; }   = string.Empty;
    [Column("Code", IsTag = true)]                  public string   Code                { get; set; }   = string.Empty;
    [Column("SubsidiaryId", IsTag = true)]          public string   SubsidiaryId        { get; set; }   = string.Empty;
    [Column("SubsidiaryUbication", IsTag = true)]   public string   SubsidiaryUbication { get; set; }   = string.Empty;
    [Column("UserEmail", IsTag = true)]             public string   UserEmail           { get; set; }   = string.Empty;
    [Column("UserName", IsTag = true)]              public string   UserName            { get; set; }   = string.Empty;
    [Column("UserRol", IsTag = true)]               public string   UserRol             { get; set; }   = string.Empty;
    [Column("UserPhoneNumber", IsTag = true)]       public string   UserPhoneNumber     { get; set; }   = string.Empty;
}
