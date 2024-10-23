using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DB;

public static class DBInjector
{
    public static void TruncateAllTables()
    {
        MySqlCommand com = new MySqlCommand("TruncateAllTables", DBConnector.GetConnection());
        com.CommandType = CommandType.StoredProcedure;
        com.ExecuteNonQuery();
    }

}
