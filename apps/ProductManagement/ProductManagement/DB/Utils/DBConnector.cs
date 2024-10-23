using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DB;

public static class DBConnector
{
    private static MySqlConnection _conn = new MySqlConnection("");

    private static string? GetConnectionString()
    {
        var config =
        new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("dbsettings.json", true)
        .Build();
        return config["DbSettings:ConnectionUrl"];
    }

    public static MySqlConnection GetConnection()
    {
        return _conn;
    }

    public static void OpenConnection()
    {
        _conn = new MySqlConnection(GetConnectionString());
        _conn.Open();
    }
}
