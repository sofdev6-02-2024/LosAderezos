using InfluxDB.Client;


namespace DB;

public static class DBConnector
{
    private static string GetTokenString()
    {
        var config =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", true)
                .Build();

        return config["DbSettings:DatabaseToken"] ?? "";
    }

    public static string GetOrganizationString()
    {
        var config =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", true)
                .Build();

        return config["DbSettings:DatabaseOrganization"] ?? "";
    }

    public static string GetBucketString()
    {
        var config =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", true)
                .Build();

        return config["DbSettings:DatabaseBucket"] ?? "";
    }

    public static string GetDatabaseUrl()
    {
        var config =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("dbsettings.json", true)
                .Build();

        return config["DbSettings:DatabaseUrl"] ?? "";
    }

    public static InfluxDBClient GetDatabaseClient()
    {
        return new InfluxDBClient(GetDatabaseUrl(), GetTokenString());
    }
}
