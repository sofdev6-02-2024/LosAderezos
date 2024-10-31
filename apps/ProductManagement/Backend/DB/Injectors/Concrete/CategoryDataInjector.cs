namespace DB;

public sealed class CategoryDataInjector : DataInjector
{
    public CategoryDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/Category.csv'" +
                            " INTO TABLE Category" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";

    }
}