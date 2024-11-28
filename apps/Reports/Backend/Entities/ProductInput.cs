using InfluxDB.Client.Core;

namespace Entities;

[Measurement("ProductInput")]
public class ProductInput
{
    [Column(IsTimestamp = true)]                public DateTime Time            { get; set; }
    [Column("Code")]                            public string   Code            { get; set; }   = string.Empty;
    [Column("ProductName")]                     public string   ProductName     { get; set; }   = string.Empty;
    [Column("Quantity")]                        public int      Quantity        { get; set; }
    [Column("IncomePrice")]                     public double   IncomePrice     { get; set; }
    [Column("Subsidiary", IsTag = true)]        public string   Subsidiary      { get; set; }   = string.Empty;
    [Column("UserEmail", IsTag = true)]         public string   UserEmail       { get; set; }   = string.Empty;
    [Column("UserName", IsTag = true)]          public string   UserName        { get; set; }   = string.Empty;
    [Column("UserRol", IsTag = true)]           public string   UserRol         { get; set; }   = string.Empty;
    [Column("UserPhoneNumber", IsTag = true)]   public string   UserPhoneNumber { get; set; }   = string.Empty;
}
