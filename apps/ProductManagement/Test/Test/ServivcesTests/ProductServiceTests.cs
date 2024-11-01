using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

public class ProductServiceTests
{
    private Mock<IProductDAO> _productDaoMock;
    private Mock<IMapper> _mapperMock;
    private ProductService _service;

    [SetUp]
    public void SetUp()
    {
        _productDaoMock = new Mock<IProductDAO>();
        _mapperMock = new Mock<IMapper>();
        _service = new ProductService(_productDaoMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task GetProducts_ReturnsMappedList()
    {
        // Arrange
        var products = new List<Product> 
        { 
            new Product { ProductId = Guid.NewGuid(), Name = "Product1" }
        };
        var expectedDtos = products.Select(p => new ProductDTO { ProductId = p.ProductId, Name = p.Name }).ToList();

        _productDaoMock.Setup(dao => dao.ReadAll()).Returns(products);
        _mapperMock.Setup(m => m.Map<ProductDTO>(It.IsAny<Product>())).Returns((Product source) => new ProductDTO { ProductId = source.ProductId, Name = source.Name });

        // Act
        var result = await _service.GetProducts();

        // Assert
        Assert.That(result.Count, Is.EqualTo(expectedDtos.Count));
        Assert.That(result[0].ProductId, Is.EqualTo(expectedDtos[0].ProductId));
        Assert.That(result[0].Name, Is.EqualTo(expectedDtos[0].Name));
    }

    [Test]
    public async Task GetProductById_ReturnsMappedDTO()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product { ProductId = productId, Name = "Product1" };
        var expectedDto = new ProductDTO { ProductId = productId, Name = "Product1" };

        _productDaoMock.Setup(dao => dao.Read(productId)).Returns(product);
        _mapperMock.Setup(m => m.Map<ProductDTO>(product)).Returns(expectedDto);

        // Act
        var result = await _service.GetProductById(productId);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.ProductId, Is.EqualTo(expectedDto.ProductId));
        Assert.That(result.Name, Is.EqualTo(expectedDto.Name));
    }

    [Test]
    public async Task CreateProduct_CreatesAndReturnsMappedDTO()
    {
        // Arrange
        var productWithoutIdDto = new ProductWithoutIDDTO { Name = "Product1" };
        var productId = Guid.NewGuid();
        var product = new Product { ProductId = productId, Name = "Product1" };
        var expectedDto = new ProductDTO { ProductId = productId, Name = "Product1" };

        _mapperMock.Setup(m => m.Map<Product>(It.IsAny<(ProductWithoutIDDTO, Guid)>())).Returns(product);
        _productDaoMock.Setup(dao => dao.Create(product));
        _productDaoMock.Setup(dao => dao.Read(It.IsAny<Guid>())).Returns(product);
        _mapperMock.Setup(m => m.Map<ProductDTO>(product)).Returns(expectedDto);

        // Act
        var result = await _service.CreateProduct(productWithoutIdDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.ProductId, Is.EqualTo(expectedDto.ProductId));
        Assert.That(result.Name, Is.EqualTo(expectedDto.Name));
    }

    [Test]
    public async Task UpdateProduct_UpdatesAndReturnsMappedDTO()
    {
        // Arrange
        var productDto = new ProductDTO { ProductId = Guid.NewGuid(), Name = "UpdatedProduct" };
        var product = new Product { ProductId = productDto.ProductId, Name = productDto.Name };

        _mapperMock.Setup(m => m.Map<Product>(productDto)).Returns(product);
        _productDaoMock.Setup(dao => dao.Update(product));
        _productDaoMock.Setup(dao => dao.Read(productDto.ProductId)).Returns(product);
        _mapperMock.Setup(m => m.Map<ProductDTO>(product)).Returns(productDto);

        // Act
        var result = await _service.UpdateProduct(productDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.ProductId, Is.EqualTo(productDto.ProductId));
        Assert.That(result.Name, Is.EqualTo(productDto.Name));
    }

}
