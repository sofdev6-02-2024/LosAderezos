using MySql.Data.MySqlClient;

namespace DB;

public abstract class DataInjector : IDataInjector
{
    private protected string? _injectionCommand;

    public int InjectData(MySqlConnection connection)
    {
        int injectionProcessResult = 0;

        try 
        {
            MySqlCommand injectionCommand = new MySqlCommand(_injectionCommand, DBConnector.GetConnection());
            injectionCommand.ExecuteNonQuery();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine(ex);
            injectionProcessResult = ex.Number;
        }
        return injectionProcessResult;
    }
}
