using System.Text;
using MySql.Data;
using Backend.Entities;
using Microsoft.Extensions.Primitives;

namespace DB;

public sealed class SubsidiaryDAO : SingleDAO<Subsidiary>, ISubsidiaryDAO
{
    public SubsidiaryDAO()
    {
        _tableName = "Subsidiary";
    }

    private protected override Subsidiary MapReaderToEntity()
    {
        _entity = new Subsidiary 
                    {
                        SubsidiaryId = _mySqlReader!.GetGuid(0),
                        Location = _mySqlReader!.GetString(1),
                        Name = _mySqlReader!.GetString(2),
                        Type = _mySqlReader!.GetString(3),
                        CompanyId = _mySqlReader!.GetGuid(4)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Subsidiary> MapReaderToEntitiesList()
    {
        _entitiesList = new List<Subsidiary>();
        while (_mySqlReader!.Read())
        {
            _entity = new Subsidiary 
                    {
                        SubsidiaryId = _mySqlReader.GetGuid(0),
                        Location = _mySqlReader.GetString(1),
                        Name = _mySqlReader.GetString(2),
                        Type = _mySqlReader.GetString(3),
                        CompanyId = _mySqlReader.GetGuid(4)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Subsidiary subsidiary)
    {
        string subsidiaryIdC = subsidiary.SubsidiaryId.ToString();
        string subsidiaryLocationC = subsidiary.Location;
        string subsidiaryNameC = subsidiary.Name;
        string subsidiaryTypeC = subsidiary.Type;
        string subsidiaryCompanyIdC = subsidiary.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Location, Name, Type, CompanyId)")
            .Append("VALUES ('").Append(subsidiaryIdC).Append("', '")
                                .Append(subsidiaryLocationC).Append("', '")
                                .Append(subsidiaryNameC).Append("', '")
                                .Append(subsidiaryTypeC).Append("', '")
                                .Append(subsidiaryCompanyIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Subsidiary subsidiary)
    {
        string subsidiaryIdC = subsidiary.SubsidiaryId.ToString();
        string subsidiaryLocationC = subsidiary.Location;
        string subsidiaryNameC = subsidiary.Name;
        string subsidiaryTypeC = subsidiary.Type;
        string subsidiaryCompanyIdC = subsidiary.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Location = '").Append(subsidiaryLocationC).Append("', ")
            .Append(" Name = '").Append(subsidiaryNameC).Append("', ")
            .Append(" Type = '").Append(subsidiaryTypeC).Append("', ")
            .Append(" CompanyId = '").Append(subsidiaryCompanyIdC).Append("' ")
            .Append(" WHERE Id = '").Append(subsidiaryIdC).Append("';");
        
        return _sb;
    }
}
