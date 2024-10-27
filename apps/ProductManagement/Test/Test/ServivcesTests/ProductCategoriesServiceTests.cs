using AutoMapper;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services;
using DB;
using Moq;

namespace Test.ServivcesTests;

[TestFixture]
public class ProductCategoriesServiceTests
{
    private Mock<IProductCategoriesDAO> _productCategoriesDaoMock;
        private Mock<IMapper> _mapperMock;
        private ProductCategoriesService _service;

        [SetUp]
        public void SetUp()
        {
            _productCategoriesDaoMock = new Mock<IProductCategoriesDAO>();
            _mapperMock = new Mock<IMapper>();
            _service = new ProductCategoriesService(_mapperMock.Object, _productCategoriesDaoMock.Object);
        }

        [Test]
        public async Task GetProductCategoriesByProductId_ReturnsMappedList()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var productCategories = new List<ProductCategories> 
            { 
                new ProductCategories { ProductId = productId, CategoryId = Guid.NewGuid() } 
            };
            var expectedDtos = productCategories.Select(pc => new ProductCategoriesDTO { ProductId = pc.ProductId, CategoryId = pc.CategoryId }).ToList();

            _productCategoriesDaoMock.Setup(dao => dao.GetProductCategoriesByProductId(productId)).Returns(productCategories);
            _mapperMock.Setup(m => m.Map<ProductCategoriesDTO>(It.IsAny<ProductCategories>())).Returns((ProductCategories source) => new ProductCategoriesDTO { ProductId = source.ProductId, CategoryId = source.CategoryId });

            // Act
            var result = await _service.GetProductCategoriesByProductId(productId);

            // Assert
            Assert.AreEqual(expectedDtos.Count, result.Count);
            Assert.AreEqual(expectedDtos[0].ProductId, result[0].ProductId);
            Assert.AreEqual(expectedDtos[0].CategoryId, result[0].CategoryId);
        }

        [Test]
        public async Task GetProductCategoriesByCategoryId_ReturnsMappedList()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var productCategories = new List<ProductCategories> 
            { 
                new ProductCategories { ProductId = Guid.NewGuid(), CategoryId = categoryId } 
            };
            var expectedDtos = productCategories.Select(pc => new ProductCategoriesDTO { ProductId = pc.ProductId, CategoryId = pc.CategoryId }).ToList();

            _productCategoriesDaoMock.Setup(dao => dao.GetProductCategoriesByCategoryId(categoryId)).Returns(productCategories);
            _mapperMock.Setup(m => m.Map<ProductCategoriesDTO>(It.IsAny<ProductCategories>())).Returns((ProductCategories source) => new ProductCategoriesDTO { ProductId = source.ProductId, CategoryId = source.CategoryId });

            // Act
            var result = await _service.GetProductCategoriesByCategoryId(categoryId);

            // Assert
            Assert.AreEqual(expectedDtos.Count, result.Count);
            Assert.AreEqual(expectedDtos[0].ProductId, result[0].ProductId);
            Assert.AreEqual(expectedDtos[0].CategoryId, result[0].CategoryId);
        }

        [Test]
        public async Task GetProductCategoryByBothIds_ReturnsMappedDTO()
        {
            // Arrange
            var productCategoryDto = new ProductCategoriesDTO { ProductId = Guid.NewGuid(), CategoryId = Guid.NewGuid() };
            var productCategory = new ProductCategories { ProductId = productCategoryDto.ProductId, CategoryId = productCategoryDto.CategoryId };

            _productCategoriesDaoMock.Setup(dao => dao.Read(productCategoryDto.ProductId, productCategoryDto.CategoryId)).Returns(productCategory);
            _mapperMock.Setup(m => m.Map<ProductCategoriesDTO>(productCategory)).Returns(productCategoryDto);

            // Act
            var result = await _service.GetProductCategoryByBothIds(productCategoryDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(productCategoryDto.ProductId, result.ProductId);
            Assert.AreEqual(productCategoryDto.CategoryId, result.CategoryId);
        }

        [Test]
        public async Task CreateProductCategory_CreatesAndReturnsMappedDTO()
        {
            // Arrange
            var productCategoryDto = new ProductCategoriesDTO { ProductId = Guid.NewGuid(), CategoryId = Guid.NewGuid() };
            var productCategory = new ProductCategories { ProductId = productCategoryDto.ProductId, CategoryId = productCategoryDto.CategoryId };

            _mapperMock.Setup(m => m.Map<ProductCategories>(productCategoryDto)).Returns(productCategory);
            _productCategoriesDaoMock.Setup(dao => dao.Create(productCategory));
            _productCategoriesDaoMock.Setup(dao => dao.Read(productCategoryDto.ProductId, productCategoryDto.CategoryId)).Returns(productCategory);
            _mapperMock.Setup(m => m.Map<ProductCategoriesDTO>(productCategory)).Returns(productCategoryDto);

            // Act
            var result = await _service.CreateProductCategory(productCategoryDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(productCategoryDto.ProductId, result.ProductId);
            Assert.AreEqual(productCategoryDto.CategoryId, result.CategoryId);
        }

        [Test]
        public async Task DeleteProductCategory_DeletesAndReturnsTrue()
        {
            // Arrange
            var productCategoryDto = new ProductCategoriesDTO { ProductId = Guid.NewGuid(), CategoryId = Guid.NewGuid() };

            _productCategoriesDaoMock.Setup(dao => dao.Delete(productCategoryDto.ProductId, productCategoryDto.CategoryId)).Returns(true);

            // Act
            var result = await _service.DeleteProductCategory(productCategoryDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteProductCategory_ReturnsFalseIfNotDeleted()
        {
            // Arrange
            var productCategoryDto = new ProductCategoriesDTO { ProductId = Guid.NewGuid(), CategoryId = Guid.NewGuid() };

            _productCategoriesDaoMock.Setup(dao => dao.Delete(productCategoryDto.ProductId, productCategoryDto.CategoryId)).Returns(false);

            // Act
            var result = await _service.DeleteProductCategory(productCategoryDto);

            // Assert
            Assert.IsFalse(result);
        }
    
}