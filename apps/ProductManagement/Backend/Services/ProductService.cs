using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class ProductService: IProductService
{
    private readonly IProductDAO _productDao;
    private readonly IStockDAO _stockDao;
    private readonly ISubsidiaryDAO _subsidiaryDao;
    private readonly IMapper _mapper;

    public ProductService(IProductDAO productDao, IMapper mapper, IStockDAO stockDao, ISubsidiaryDAO subsidiaryDao)
    {
        _productDao = productDao;
        _mapper = mapper;
        _stockDao = stockDao;
        _subsidiaryDao = subsidiaryDao;
    }

    public List<ProductDTO> GetProducts()
    {
        return _productDao.ReadAll().Select(_mapper.Map<ProductDTO>).ToList();
    }

    public ProductDTO? GetProductById(Guid id)
    {
        return _mapper.Map<ProductDTO>(_productDao.Read(id));
    }

    public ProductDTO CreateProduct(ProductWithoutIDDTO product)
    {
        Guid guid = Guid.NewGuid();
        _productDao.Create(_mapper.Map<Product>((product, guid)));
        foreach (Subsidiary subsidiary in _subsidiaryDao.ReadAll())
        {
            _stockDao.Create(new Stock()
            {
                ProductId = guid,
                Code = 0,
                Quantity = 0,
                StockId = Guid.NewGuid(),
                SubsidiaryId = subsidiary.SubsidiaryId
            });
        }
        return _mapper.Map<ProductDTO>(_productDao.Read(guid));
    }

    public ProductDTO UpdateProduct(ProductDTO product)
    {
        _productDao.Update(_mapper.Map<Product>(product));
        return _mapper.Map<ProductDTO>(_productDao.Read(product.ProductId));
    }
}
