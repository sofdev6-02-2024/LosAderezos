using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class SessionTokenDAO : SingleDAO<SessionToken>, ISessionTokenDAO
{
    public SessionTokenDAO()
    {
        _tableName = "SessionToken";
    }

    private protected override SessionToken MapReaderToEntity()
    {
        _entity = new SessionToken
        {
            Token = _mySqlReader!.GetString(0),
            Time = _mySqlReader.GetDateTime(1),
            UserId = _mySqlReader.GetGuid(2)
        };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<SessionToken> MapReaderToEntitiesList()
    {
        _entitiesList = new List<SessionToken>();
        return _entitiesList;
    }
    
    private protected override StringBuilder CreateCommandIntoStringBuilder(SessionToken session)
    {
        string sessionTokenC = session.Token;
        string sessionTimeC = session.Time.ToString("yyyy-MM-dd H:mm:ss");
        string sessionUserIdC = session.UserId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Token, Time, Id) ")
            .Append("VALUES ('").Append(sessionTokenC).Append("', '")
            .Append(sessionTimeC).Append("', '")
            .Append(sessionUserIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(SessionToken session)
    {
        _sb = new StringBuilder();
        return _sb;
    }
}
