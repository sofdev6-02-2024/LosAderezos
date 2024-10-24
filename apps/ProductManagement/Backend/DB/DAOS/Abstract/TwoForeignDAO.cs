using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DB;

public abstract class TwoForeignDAO<T> : ITwoForeignDAO<T>
{
    private protected string _tableName = string.Empty;

    private protected string _firstForeignKey = string.Empty;

    private protected string _secondForeignKey = string.Empty;

    private protected StringBuilder? _sb;

    private protected List<T>? _entitiesList;

    private protected MySqlDataReader? _mySqlReader;
    
    private protected T? _entity;
    
    private MySqlCommand? _dbCommand; 

    public int Create(T entity)
    {
        return  ExecuteCreateOperation(entity);
    }

    public List<T> ReadAll()
    {
        return  ExecuteReadAllOperation();
    }

    public T? Read(Guid id1, Guid id2)
    {
        return ExecuteReadOperation(id1, id2);
    }

    public bool Delete(Guid id1, Guid id2)
    {
        return ExecuteDeleteOperation(id1, id2);
    }

    public int Update(T entity)
    {
        return ExecuteUpdateOperation(entity);
    }

    private protected int ExecuteUpdateOperation(T entity)
    {
        _sb = UpdateCommandIntoStringBuilder(entity);
        MySqlCommand com = GetCommandByText(_sb);
        _mySqlReader = com.ExecuteReader();
        int toReturn = _mySqlReader.RecordsAffected;
        _mySqlReader.Close();
        return toReturn;
    }

    private protected int ExecuteCreateOperation(T entity)
    {
        _sb = CreateCommandIntoStringBuilder(entity);
        MySqlCommand com = GetCommandByText(_sb);
        return com.ExecuteNonQuery();
    }

    private protected List<T> ExecuteReadAllOperation()
    {
        MySqlCommand com = GetCommandTableDirect();
        _mySqlReader = com.ExecuteReader();
        return MapReaderToEntitiesList();
    }

    private protected T? ExecuteReadOperation(Guid id1, Guid id2)
    {
        _sb = new StringBuilder();
        _sb.Append("SELECT * FROM ").Append(_tableName)
            .Append(" WHERE ").Append(_firstForeignKey).Append(" = '").Append(id1.ToString()).Append("' ")
            .Append(" AND ").Append(_secondForeignKey).Append(" = '").Append(id2.ToString()).Append("';");
        MySqlCommand com = GetCommandByText(_sb);
        _mySqlReader = com.ExecuteReader();
        if (!_mySqlReader.HasRows)
        {
            _mySqlReader.Close();
            return default(T);
        }
        _mySqlReader.Read();

        return MapReaderToEntity();
    }

    private protected bool ExecuteDeleteOperation(Guid id1, Guid id2)
    {
        _sb = new StringBuilder();
        _sb.Append("DELETE FROM ").Append(_tableName)
            .Append(" WHERE ").Append(_firstForeignKey).Append(" = '").Append(id1.ToString()).Append("' ")
            .Append(" AND ").Append(_secondForeignKey).Append(" = '").Append(id2.ToString()).Append("';");
        MySqlCommand com = GetCommandByText(_sb);
        _mySqlReader = com.ExecuteReader();
        int recordsAffected = _mySqlReader.RecordsAffected;
        _mySqlReader.Close();

        return recordsAffected > 0;
    }

    private protected MySqlCommand GetCommandTableDirect()
    {
        _dbCommand = new MySqlCommand();
        _dbCommand.Connection = DBConnector.GetConnection();
        _dbCommand.CommandText = _tableName;
        _dbCommand.CommandType = CommandType.TableDirect;
        return _dbCommand;
    }

    private protected MySqlCommand GetCommandStoredProcedure(string procedureName)
    {
        _dbCommand = new MySqlCommand(procedureName,DBConnector.GetConnection());
        _dbCommand.CommandType = CommandType.StoredProcedure;
        return _dbCommand;
    }

    private protected MySqlCommand GetCommandByText(StringBuilder sb)
    {
        _dbCommand = new MySqlCommand();
        _dbCommand.Connection = DBConnector.GetConnection();
        _dbCommand.CommandText = sb.ToString();
        return _dbCommand;
    }

    private protected abstract T MapReaderToEntity();

    private protected abstract List<T> MapReaderToEntitiesList();

    private protected abstract StringBuilder CreateCommandIntoStringBuilder(T entity);

    private protected abstract StringBuilder UpdateCommandIntoStringBuilder(T entity);
}
