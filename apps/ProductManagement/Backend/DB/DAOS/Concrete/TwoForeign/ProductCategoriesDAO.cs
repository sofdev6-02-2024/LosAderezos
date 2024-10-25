using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Backend.Entities;

namespace DB;

public sealed class ProductCategoriesDAO :  TwoForeignDAO<ProductCategories> , IProductCategoriesDAO
{
    public ProductCategoriesDAO()
    {
        _tableName = "ProductCategories";
        _firstForeignKey = "ProductId";
        _secondForeignKey = "CategoryId";
    }

    private protected override ProductCategories MapReaderToEntity()
    {
        _entity = new ProductCategories
                    {
                        ProductId = _mySqlReader!.GetGuid(0),
                        CategoryId = _mySqlReader!.GetGuid(1)
                    };
        _mySqlReader.Close();
        return _entity;
    }

    private protected override List<ProductCategories> MapReaderToEntitiesList()
    {
        _entitiesList = new List<ProductCategories>();
        while (_mySqlReader!.Read())
        {
            _entity = new ProductCategories
                    {
                        ProductId = _mySqlReader!.GetGuid(0),
                        CategoryId = _mySqlReader!.GetGuid(1)
                    };
            _entitiesList.Add(_entity);
        }
        _mySqlReader.Close();
        return _entitiesList;
    }

    private protected override StringBuilder CreateCommandIntoStringBuilder(ProductCategories productCategories)
    {
        string productCategoriesProductIdC = productCategories.ProductId.ToString();
        string productCategoriesCategoryIdC = productCategories.CategoryId.ToString();

        _sb = new StringBuilder();
        _sb.Append("INSERT INTO ").Append(_tableName).Append(" (").Append(_firstForeignKey).Append(",").Append(_secondForeignKey).Append(")")
            .Append("VALUES ('").Append(productCategoriesProductIdC).Append("','")
                                .Append(productCategoriesCategoryIdC).Append("');");
        return _sb;
    }

    private protected override StringBuilder UpdateCommandIntoStringBuilder(ProductCategories productCategories)
    {
        string productCategoriesProductIdC = productCategories.ProductId.ToString();
        string productCategoriesCategoryIdC = productCategories.CategoryId.ToString();
        _sb = new StringBuilder();
        return _sb;
    }

    public List<ProductCategories> GetProductCategoriesByProductId(Guid productId)
    {
        string productIdC = productId.ToString();

        MySqlCommand com = GetCommandStoredProcedure("GetProductCategoriesByProductId");
        com.Parameters.AddWithValue("@productId", productIdC);
        com.Parameters["@productId"].Direction = ParameterDirection.Input;

        _mySqlReader = com.ExecuteReader();
        return MapReaderToEntitiesList();
    }

    public List<ProductCategories> GetProductCategoriesByCategoryId(Guid categoryId)
    {
        string categoryIdC = categoryId.ToString();

        MySqlCommand com = GetCommandStoredProcedure("GetProductCategoriesByCategoryId");
        com.Parameters.AddWithValue("@categoryId", categoryIdC);
        com.Parameters["@categoryId"].Direction = ParameterDirection.Input;

        _mySqlReader = com.ExecuteReader();
        return MapReaderToEntitiesList();
    }
}
