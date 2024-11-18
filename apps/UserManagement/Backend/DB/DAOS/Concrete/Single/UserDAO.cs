using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class UserDAO : SingleDAO<User>, IUserDAO
{
    public UserDAO()
    {
        _tableName = "User";
    }

    private protected override User MapReaderToEntity()
    {
        _entity = new User
        {
            UserId = _mySqlReader!.GetGuid(0),
            Name = _mySqlReader.GetString(1),
            Rol = _mySqlReader.GetString(2),
            Email = _mySqlReader.GetString(3),
            PhoneNumber = _mySqlReader.GetString(4),
            BirthDate = _mySqlReader.GetDateTime(5)
        };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<User> MapReaderToEntitiesList()
    {
        _entitiesList = new List<User>();
        while (_mySqlReader!.Read())
        {
            _entity = new User
            {
                UserId = _mySqlReader.GetGuid(0),
                Name = _mySqlReader.GetString(1),
                Rol = _mySqlReader.GetString(2),
                Email = _mySqlReader.GetString(3),
                PhoneNumber = _mySqlReader.GetString(4),
                BirthDate = _mySqlReader.GetDateTime(5)
            };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }
    
    private protected override StringBuilder CreateCommandIntoStringBuilder(User user)
    {
        string userIdC = user.UserId.ToString();
        string userNameC = user.Name;
        string userRolC = user.Rol;
        string userEmailC = user.Email;
        string userPhoneNumberC  = user.PhoneNumber;
        string userBirthdateC = user.BirthDate.ToString("yyyy-MM-dd");

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, name, Rol, Email, PhoneNumber, Birthdate)")
            .Append("VALUES ('").Append(userIdC).Append("', '")
            .Append(userNameC).Append("', '")
            .Append(userRolC).Append("', '")
            .Append(userEmailC).Append("', '")
            .Append(userPhoneNumberC).Append("', '")
            .Append(userBirthdateC).Append("');");
        _mySqlReader?.Close();
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(User user)
    {
        string userIdC = user.UserId.ToString();
        string userNameC = user.Name;
        string userRolC = user.Rol;
        string userEmailC = user.Email;
        string userPhoneNumberC  = user.PhoneNumber;
        string userBirthdateC = user.BirthDate.ToString("yyyy-MM-dd");

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set name = '").Append(userNameC).Append("', Rol = '")
                .Append(userRolC).Append("', Email = '")
                .Append(userEmailC).Append("', PhoneNumber = '")
                .Append(userPhoneNumberC).Append("', Birthdate = '")
                .Append(userBirthdateC).Append("'")
                .Append(" WHERE Id = '").Append(userIdC).Append("';");
        _mySqlReader?.Close();
        return _sb;
    }
    
    
}
