using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;

namespace DB;

public abstract class DAO<T> : IDAO<T>
{
    private protected IWriteApi _writer;
    
    public DAO()
    {
        _writer = DBConnector.GetDatabaseClient().GetWriteApi();
    }

    public void Write(T entity)
    {
        _writer.WriteMeasurement(entity, WritePrecision.Ns,DBConnector.GetBucketString(), DBConnector.GetOrganizationString());
    }
}
