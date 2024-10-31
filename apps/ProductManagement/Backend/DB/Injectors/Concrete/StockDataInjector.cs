namespace DB;

public sealed class StockDataInjector : DataInjector
{
    public StockDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/Stock.csv'" +  
                            " INTO TABLE Stock" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";
    }
}
