namespace DB;

public sealed class ProductDataInjector : DataInjector
{
    public ProductDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/Product.csv'" +
                            " INTO TABLE Product" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES" +
                            " (Id,Name,IncomePrice,Code,SellPrice,CompanyId,LowExistence,@Notify) SET" +
                            " Notify = CAST(@Notify as signed); ";
    }
}
