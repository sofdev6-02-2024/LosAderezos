using MySql.Data.MySqlClient;

namespace DB;

public interface IDataInjector
{
    int InjectData(MySqlConnection connection);
}