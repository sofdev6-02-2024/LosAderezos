using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class CategoryDAO : SingleDAO<Category>
{
    public CategoryDAO()
    {
        _tableName = "Category";
    }

    private protected override Category MapReaderToEntity()
    {
        _entity = new Category 
                    {
                        CategoryId = _mySqlReader!.GetGuid(0),
                        Name = _mySqlReader!.GetString(1)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Category> MapReaderToEntitiesList()
    {
        _entitiesList = new List<Category>();
        while (_mySqlReader!.Read())
        {
            _entity = new Category
                        {
                            CategoryId = _mySqlReader.GetGuid(0),
                            Name = _mySqlReader.GetString(1)
                        };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Category category)
    {
        string categoryIdC = category.CategoryId.ToString();
        string categoryNameC = category.Name;

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Name)")
            .Append("VALUES ('").Append(categoryIdC).Append("','")
                                .Append(categoryNameC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Category category)
    {
        string categoryIdC = category.CategoryId.ToString();
        string categoryNameC = category.Name;

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Name = '").Append(categoryNameC).Append("' ")
            .Append(" WHERE Id = '").Append(categoryIdC).Append("';");
        
        return _sb;
    }
}
