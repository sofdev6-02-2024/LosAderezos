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
        string code = CreateCodeFromGuid(guid);
        _productDao.Create(_mapper.Map<Product>((product, guid, code)));
        return _mapper.Map<ProductDTO>(_productDao.Read(guid));
    }

    public ProductDTO? UpdateProduct(Guid productId, ProductWithoutIDDTO product)
    {
        string code = CreateCodeFromGuid(productId);
        _productDao.Update(_mapper.Map<Product>((product, productId, code)));
        var resultProduct = _productDao.Read(productId);
        return _mapper.Map<ProductDTO>(resultProduct);
    }

    private string CreateCodeFromGuid(Guid guid)
    {
        return guid.ToString("N");   
    }
}
