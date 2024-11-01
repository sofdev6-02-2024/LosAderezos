using System.Data;
using MySql.Data.MySqlClient;

namespace DB;

public class DBInjector
{
    private static MySqlConnection _conn = DBConnector.GetConnection();
    public static void TruncateAllTables()
    {
        MySqlCommand com = new MySqlCommand("TruncateAllTables", _conn);
        com.CommandType = CommandType.StoredProcedure;
        com.ExecuteNonQuery();
    }

    public static void InjectData()
    {
        IDataInjector injector = new UserDataInjector();
        injector.InjectData(_conn);
    }
}
