namespace DB;

public sealed class ProductCategoriesDataInjector : DataInjector
{
    public ProductCategoriesDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/ProductCategories.csv'" +  
                            " INTO TABLE ProductCategories" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";
    }
}