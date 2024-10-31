namespace DB;

public sealed class SubsidiaryDataInjector : DataInjector
{
    public SubsidiaryDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/Subsidiary.csv'" +  
                            " INTO TABLE Subsidiary" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";
    }
}
