using System.Data;
using MySql.Data.MySqlClient;

namespace DB;

public static class DBInjector
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
        IDataInjector injector = new CategoryDataInjector();
        injector.InjectData(_conn);

        injector = new CompanyDataInjector();
        injector.InjectData(_conn);
        
        injector = new SubsidiaryDataInjector();
        injector.InjectData(_conn);
        
        injector = new ProductDataInjector();
        injector.InjectData(_conn);
        
        injector = new StockDataInjector();
        injector.InjectData(_conn);
        
        injector = new SubsidiaryUsersDataInjector();
        injector.InjectData(_conn);

        injector = new ProductCategoriesDataInjector();
        injector.InjectData(_conn);
    }
}