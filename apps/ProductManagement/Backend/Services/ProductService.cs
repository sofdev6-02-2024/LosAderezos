using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class ProductService: IProductService
{
    private readonly IProductDAO _productDao;
    private readonly IMapper _mapper;

    public ProductService(IProductDAO productDao, IMapper mapper)
    {
        _productDao = productDao;
        _mapper = mapper;
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
        return _mapper.Map<ProductDTO>(_productDao.Read(guid));
    }

    public ProductDTO UpdateProduct(ProductDTO product)
    {
        _productDao.Update(_mapper.Map<Product>(product));
        return _mapper.Map<ProductDTO>(_productDao.Read(product.ProductId));
    }
}
