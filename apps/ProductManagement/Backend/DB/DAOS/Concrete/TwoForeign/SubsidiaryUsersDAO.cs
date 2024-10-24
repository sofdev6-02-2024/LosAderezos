using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Backend.Entities;

namespace DB;

public sealed class SubsidiaryUsersDAO :  TwoForeignDAO<SubsidiaryUsers> , ISubsidiaryUsersDAO
{
    public SubsidiaryUsersDAO()
    {
        _tableName = "SubsidiaryUsers";
        _firstForeignKey = "UserId";
        _secondForeignKey = "SubsidiaryId";
    }

    private protected override SubsidiaryUsers MapReaderToEntity()
    {
        _entity = new SubsidiaryUsers
                    {
                        UserId = _mySqlReader!.GetGuid(0),
                        SubsidiaryId = _mySqlReader!.GetGuid(1)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<SubsidiaryUsers> MapReaderToEntitiesList()
    {
        _entitiesList = new List<SubsidiaryUsers>();
        while (_mySqlReader!.Read())
        {
            _entity = new SubsidiaryUsers
                    {
                        UserId = _mySqlReader!.GetGuid(0),
                        SubsidiaryId = _mySqlReader!.GetGuid(1)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(SubsidiaryUsers subsidiaryUsers)
    {
        string subsidiaryUsersUserIdC = subsidiaryUsers.UserId.ToString();
        string subsidiaryUsersSubsidiaryIdC = subsidiaryUsers.SubsidiaryId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (").Append(_firstForeignKey).Append(",").Append(_secondForeignKey).Append(")")
            .Append("VALUES ('").Append(subsidiaryUsersUserIdC).Append("','")
                                .Append(subsidiaryUsersSubsidiaryIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(SubsidiaryUsers subsidiaryUsers)
    {
        string subsidiaryUsersUserIdC = Guid.Empty.ToString();
        string subsidiaryUsersSubsidiaryIdC = Guid.Empty.ToString();
        _sb = new StringBuilder();
        return _sb;
    }

    public List<SubsidiaryUsers> GetSubsidiaryUsersByUserId(Guid userId)
    {
        string userIdC = userId.ToString();

        MySqlCommand com = GetCommandStoredProcedure("GetSubsidiaryUsersByUserId");
        com.Parameters.AddWithValue("@userId", userIdC);
        com.Parameters["@userId"].Direction = ParameterDirection.Input;

        _mySqlReader = com.ExecuteReader();
        return MapReaderToEntitiesList();
    }

    public List<SubsidiaryUsers> GetSubsidiaryUsersBySubsidiaryId(Guid subsidiaryId)
    {
        string subsidiaryIdC = subsidiaryId.ToString();

        MySqlCommand com = GetCommandStoredProcedure("GetSubsidiaryUsersBySubsidiaryId");
        com.Parameters.AddWithValue("@subsidiaryId", subsidiaryIdC);
        com.Parameters["@subsidiaryId"].Direction = ParameterDirection.Input;

        _mySqlReader = com.ExecuteReader();
        return MapReaderToEntitiesList();
    }
}
