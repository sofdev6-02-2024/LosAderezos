namespace DB;

public sealed class UserDataInjector : DataInjector
{
    public UserDataInjector()
    {
        _injectionCommand = @"LOAD DATA INFILE '/var/lib/mysql-files/User.csv'" +
                            " INTO TABLE User" +
                            " FIELDS TERMINATED BY ','" +
                            " IGNORE 1 LINES" + 
                            " (Id,Name,Rol,Email,PhoneNumber,@BirthDate) SET" +
                            " BirthDate = CAST(@BirthDate AS DATETIME);";
    }
}