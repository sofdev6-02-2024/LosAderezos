using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class ProductService: IProductService
{
    private readonly IProductDAO _productDao;
    private readonly IProductCategoriesDAO _productCategoriesDao;
    private readonly ISubsidiaryDAO _subsidiaryDao;
    private readonly IStockDAO _stockDao;
    private readonly IMapper _mapper;

    public ProductService(IProductDAO productDao, IMapper mapper, ISubsidiaryDAO subsidiaryDao, IStockDAO stockDao, IProductCategoriesDAO productCategoriesDao)
    {
        _productDao = productDao;
        _mapper = mapper;
        _subsidiaryDao = subsidiaryDao;
        _stockDao = stockDao;
        _productCategoriesDao = productCategoriesDao;
    }

    public List<ProductDTO> GetProducts()
    {
        return _productDao.ReadAll().Select(_mapper.Map<ProductDTO>).ToList();
    }

    public ProductDTO? GetProductById(Guid id)
    {
        return _mapper.Map<ProductDTO>(_productDao.Read(id));
    }

    public ProductDTO? CreateProduct(ProductWithoutIDDTO product)
    {
        Guid guid = Guid.NewGuid();
        if (string.IsNullOrEmpty(product.Code))
        {
            product.Code = CreateCodeFromGuid(guid);
        }

        if (_productDao.ReadAll().Any(p => p.Code == product.Code))
        {
            return null;
        }
        _productDao.Create(_mapper.Map<Product>((product, guid)));
        foreach (Subsidiary subsidiary in _subsidiaryDao.ReadAll())
        {
            _stockDao.Create(new Stock()
            {
                ProductId = guid,
                Quantity = 0,
                StockId = Guid.NewGuid(),
                SubsidiaryId = subsidiary.SubsidiaryId
            });
        }
        return _mapper.Map<ProductDTO>(_productDao.Read(guid));
    }

    public ProductDTO? UpdateProduct(Guid productId, ProductWithoutIDDTO product)
    {
        if (string.IsNullOrEmpty(product.Code))
        {
            product.Code = CreateCodeFromGuid(productId);
        }

        if (_productDao.ReadAll().Any(p => p.Code == product.Code))
        {
            return null;
        }
        _productDao.Update(_mapper.Map<Product>((product, productId)));
        var resultProduct = _productDao.Read(productId);
        return _mapper.Map<ProductDTO>(resultProduct);
    }

    public bool? DeleteProductById(Guid id)
    {
        var existingProduct = _productDao.Read(id);
        if (existingProduct == null)
        {
            return null;
        }
        foreach (Stock stock in _stockDao.ReadAll())
        {
            if (stock.ProductId == existingProduct.ProductId)
            {
                _stockDao.Delete(stock.StockId);    
            }
        }
        foreach (ProductCategories productCategories in _productCategoriesDao.GetProductCategoriesByProductId(existingProduct.ProductId))
        {
            _productCategoriesDao.Delete(productCategories.ProductId, productCategories.CategoryId);
        }
        
        _productDao.Delete(existingProduct.ProductId);
        return true;
    }

    private string CreateCodeFromGuid(Guid guid)
    {
        return guid.ToString("N").Substring(0, 10);   
    }
}
