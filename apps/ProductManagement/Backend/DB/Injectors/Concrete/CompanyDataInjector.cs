namespace DB;

public sealed class CompanyDataInjector : DataInjector
{
    public CompanyDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/Company.csv'" +
                            " INTO TABLE Company" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";
    }
}