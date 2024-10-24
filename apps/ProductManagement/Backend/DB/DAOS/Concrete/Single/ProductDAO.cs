using System.Text;
using MySql.Data;
using Backend.Entities;

namespace DB;

public sealed class ProductDAO : SingleDAO<Product>
{
    public ProductDAO()
    {
        _tableName = "Product";
    }

    private protected override Product MapReaderToEntity()
    {
        _entity = new Product 
                    {
                        ProductId = _mySqlReader!.GetGuid(0),
                        Name = _mySqlReader!.GetString(1),
                        IncomingPrice = _mySqlReader!.GetDecimal(2),
                        Code = _mySqlReader!.GetInt32(3),
                        SellPrice = _mySqlReader!.GetDecimal(4),
                        CompanyId = _mySqlReader!.GetGuid(5)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<Product> MapReaderToEntitiesList()
    {
        _entitiesList = new List<Product>();
        while (_mySqlReader!.Read())
        {
            _entity = new Product 
                    {
                        ProductId = _mySqlReader.GetGuid(0),
                        Name = _mySqlReader.GetString(1),
                        IncomingPrice = _mySqlReader.GetDecimal(2),
                        Code = _mySqlReader.GetInt32(3),
                        SellPrice = _mySqlReader.GetDecimal(4),
                        CompanyId = _mySqlReader.GetGuid(5)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(Product product)
    {
        string productIdC = product.ProductId.ToString();
        string productNameC = product.Name;
        string productIncomingPriceC = product.IncomingPrice.ToString();
        string productCodeC = product.Code.ToString();
        string productSellPriceC = product.SellPrice.ToString();
        string productCompanyIdC = product.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (Id, Name, IncomePrice, Code, SellPrice, CompanyId)")
            .Append("VALUES ('").Append(productIdC).Append("','")
                                .Append(productNameC).Append("',")
                                .Append(productIncomingPriceC).Append(",")
                                .Append(productCodeC).Append(",")
                                .Append(productSellPriceC).Append(",'")
                                .Append(productCompanyIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(Product product)
    {
        string productIdC = product.ProductId.ToString();
        string productNameC = product.Name;
        string productIncomingPriceC = product.IncomingPrice.ToString();
        string productCodeC = product.Code.ToString();
        string productSellPriceC = product.SellPrice.ToString();
        string productCompanyIdC = product.CompanyId.ToString();

        _sb = new StringBuilder();
        _sb.Append("UPDATE ").Append(_tableName)
            .Append(" Set Name = '").Append(productNameC).Append("', ")
            .Append(" IncomePrice = ").Append(productIncomingPriceC).Append(", ")
            .Append(" Code = ").Append(productCodeC).Append(", ")
            .Append(" SellPrice = ").Append(productSellPriceC).Append(", ")
            .Append(" CompanyId = '").Append(productCompanyIdC).Append("' ")
            .Append(" WHERE Id = '").Append(productIdC).Append("';");
        
        return _sb;
    }
}
