using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class ProductService: IProductService
{
    private readonly IDAO<Product> _productDao;
    private readonly ISingleDAO<Product> _singleProductDao;
    private readonly IMapper _mapper;

    public ProductService(IDAO<Product> productDao, IMapper mapper, ISingleDAO<Product> singleProductDao)
    {
        _productDao = productDao;
        _mapper = mapper;
        _singleProductDao = singleProductDao;
    }

    public async Task<List<ProductDTO>> GetProducts()
    {
        return _productDao.ReadAll().Select(_mapper.Map<ProductDTO>).ToList();
    }

    public async Task<ProductDTO> GetProductById(Guid id)
    {
        return _mapper.Map<ProductDTO>(_singleProductDao.Read(id));
    }

    public async Task<ProductDTO> CreateProduct(ProductWithoutIDDTO product)
    {
        return _mapper.Map<ProductDTO>(_singleProductDao.Create(_mapper.Map<Product>(product)));
    }

    public async Task<ProductDTO> UpdateProduct(ProductDTO product)
    {
        return _mapper.Map<ProductDTO>(_singleProductDao.Update(_mapper.Map<Product>(product)));
    }
}
