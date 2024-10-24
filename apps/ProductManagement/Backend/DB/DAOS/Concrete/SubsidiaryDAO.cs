using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class SubsidiaryDAO : SingleDAO<Subsidiary>
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
                        Latitude = _mySqlReader!.GetDecimal(1),
                        Longitude = _mySqlReader!.GetDecimal(2),
                        Name = _mySqlReader!.GetString(3),
                        Type = _mySqlReader!.GetString(4),
                        CompanyId = _mySqlReader!.GetGuid(5)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Subsidiary> MapReaderToEntitiesMap()
    {
        _entitiesList = new List<Subsidiary>();
        while (_mySqlReader!.Read())
        {
            _entity = new Subsidiary 
                    {
                        SubsidiaryId = _mySqlReader.GetGuid(0),
                        Latitude = _mySqlReader.GetDecimal(1),
                        Longitude = _mySqlReader.GetDecimal(2),
                        Name = _mySqlReader.GetString(3),
                        Type = _mySqlReader.GetString(4),
                        CompanyId = _mySqlReader.GetGuid(5)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Subsidiary subsidiary)
    {
        string subsidiaryIdC = subsidiary.SubsidiaryId.ToString();
        string subsidiaryLatitudeC = subsidiary.Latitude.ToString();
        string subsidiaryLongitudeC = subsidiary.Latitude.ToString();
        string subsidiaryNameC = subsidiary.Name;
        string subsidiaryTypeC = subsidiary.Type;
        string subsidiaryCompanyIdC = subsidiary.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Latitude, Longitude, Name, Type, CompanyId)")
            .Append("VALUES ('").Append(subsidiaryIdC).Append("',")
                                .Append(subsidiaryLatitudeC).Append(",")
                                .Append(subsidiaryLongitudeC).Append(",'")
                                .Append(subsidiaryNameC).Append("','")
                                .Append(subsidiaryTypeC).Append("','")
                                .Append(subsidiaryCompanyIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Subsidiary subsidiary)
    {
        string subsidiaryIdC = subsidiary.SubsidiaryId.ToString();
        string subsidiaryLatitudeC = subsidiary.Latitude.ToString();
        string subsidiaryLongitudeC = subsidiary.Latitude.ToString();
        string subsidiaryNameC = subsidiary.Name;
        string subsidiaryTypeC = subsidiary.Type;
        string subsidiaryCompanyIdC = subsidiary.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Latitude = ").Append(subsidiaryLatitudeC).Append(", ")
            .Append(" Longitude = ").Append(subsidiaryLongitudeC).Append(", ")
            .Append(" Name = '").Append(subsidiaryNameC).Append("',")
            .Append(" Type = '").Append(subsidiaryTypeC).Append("', ")
            .Append(" CompanyId = '").Append(subsidiaryCompanyIdC).Append("' ")
            .Append(" WHERE Id = '").Append(subsidiaryIdC).Append("';");
        
        return _sb;
    }
}
