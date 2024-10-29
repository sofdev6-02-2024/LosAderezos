using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface IProductService
{
    public Task<List<ProductDTO>> GetProducts();
    public Task<ProductDTO> GetProductById(Guid id);
    public Task<ProductDTO> CreateProduct(ProductWithoutIDDTO product);
    public Task<ProductDTO> UpdateProduct(ProductDTO product);
}
