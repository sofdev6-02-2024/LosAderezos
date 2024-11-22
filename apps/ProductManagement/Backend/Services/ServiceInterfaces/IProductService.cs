using Backend.DTOs.WithID;
using Backend.Entities;

namespace Backend.Services.ServiceInterfaces;

public interface IProductService
{
    public List<ProductDTO> GetProducts();
    public ProductDTO? GetProductById(Guid id);
    public ProductDTO CreateProduct(ProductWithoutIDDTO product);
    public ProductDTO? UpdateProduct(Guid productId, ProductWithoutIDDTO product);
    public bool? DeleteProductById(Guid id);
}
