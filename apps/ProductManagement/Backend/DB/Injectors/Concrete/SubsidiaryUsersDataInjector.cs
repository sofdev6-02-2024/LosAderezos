namespace DB;

public sealed class SubsidiaryUsersDataInjector : DataInjector
{
    public SubsidiaryUsersDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/SubsidiaryUsers.csv'" +  
                            " INTO TABLE SubsidiaryUsers" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES";
    }
}