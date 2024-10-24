using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class CompanyDAO : SingleDAO<Company>
{
    public CompanyDAO()
    {
        _tableName = "Company";
    }

    private protected override Company MapReaderToEntity()
    {
        _entity = new Company 
                    {
                        CompanyId = _mySqlReader!.GetGuid(0),
                        Name = _mySqlReader!.GetString(1),
                        UserId = _mySqlReader!.GetGuid(2)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Company> MapReaderToEntitiesMap()
    {
        _entitiesList = new List<Company>();
        while (_mySqlReader!.Read())
        {
            _entity = new Company
                        {
                            CompanyId = _mySqlReader.GetGuid(0),
                            Name = _mySqlReader.GetString(1),
                            UserId = _mySqlReader.GetGuid(2)
                        };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Company company)
    {
        string companyIdC = company.CompanyId.ToString();
        string companyNameC = company.Name;
        string companyUserIdC = company.UserId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Name, UserId)")
            .Append("VALUES ('").Append(companyIdC).Append("','")
                                .Append(companyNameC).Append("','")
                                .Append(companyUserIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Company company)
    {
        string companyIdC = company.CompanyId.ToString();
        string companyNameC = company.Name;
        string companyUserIdC = company.UserId.ToString();

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Name = '").Append(companyNameC).Append("', ")
            .Append(" UserId = '").Append(companyUserIdC).Append("' ")
            .Append(" WHERE Id = '").Append(companyIdC).Append("';");
        
        return _sb;
    }
}
