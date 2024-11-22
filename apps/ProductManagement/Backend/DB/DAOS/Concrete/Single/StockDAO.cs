using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class StockDAO : SingleDAO<Stock>, IStockDAO
{
    public StockDAO()
    {
        _tableName = "Stock";
    }

    private protected override Stock MapReaderToEntity()
    {
        _entity = new Stock 
                    {
                        StockId = _mySqlReader!.GetGuid(0),
                        Quantity = _mySqlReader!.GetInt32(1),
                        ProductId = _mySqlReader!.GetGuid(2),
                        SubsidiaryId = _mySqlReader!.GetGuid(3),
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Stock> MapReaderToEntitiesList()
    {
        _entitiesList = new List<Stock>();
        while (_mySqlReader!.Read())
        {
            _entity = new Stock 
                    {
                        StockId = _mySqlReader.GetGuid(0),
                        Quantity = _mySqlReader.GetInt32(1),
                        ProductId = _mySqlReader.GetGuid(2),
                        SubsidiaryId = _mySqlReader.GetGuid(3)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Stock stock)
    {
        string stockIdC = stock.StockId.ToString();
        string stockQuantityC = stock.Quantity.ToString();
        string stockProductIdC = stock.ProductId.ToString();
        string stockSubsidiaryIdC = stock.SubsidiaryId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Quantity, ProductId, SubsidiaryId)")
            .Append("VALUES ('").Append(stockIdC).Append("',")
                                .Append(stockQuantityC).Append(",'")
                                .Append(stockProductIdC).Append("','")
                                .Append(stockSubsidiaryIdC).Append("');");
            
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Stock stock)
    {
        string stockIdC = stock.StockId.ToString();
        string stockQuantityC = stock.Quantity.ToString();
        string stockProductIdC = stock.ProductId.ToString();
        string stockSubsidiaryIdC = stock.SubsidiaryId.ToString();

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Quantity = ").Append(stockQuantityC).Append(", ")
            .Append(" ProductId = '").Append(stockProductIdC).Append("',")
            .Append(" SubsidiaryId = '").Append(stockSubsidiaryIdC).Append("' ")
            .Append(" WHERE Id = '").Append(stockIdC).Append("';");
        
        return _sb;
    }
}
