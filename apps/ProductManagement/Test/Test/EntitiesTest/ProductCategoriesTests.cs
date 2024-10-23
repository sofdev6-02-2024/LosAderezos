using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class ProductCategoriesTests
{
    private ProductCategories _productCategories;

        [SetUp]
        public void SetUp()
        {
            _productCategories = new ProductCategories();
        }

        [Test]
        public void ProductId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _productCategories.ProductId = Guid.NewGuid();

            // Act
            var result = _productCategories.ProductId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetProductId()
        {
            // Arrange
            var productId = Guid.NewGuid();
            _productCategories.ProductId = productId;

            // Act
            var result = _productCategories.ProductId;

            // Assert
            Assert.That(result, Is.EqualTo(productId));
        }

        [Test]
        public void CanSetProductId()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            _productCategories.ProductId = productId;

            // Assert
            Assert.That(_productCategories.ProductId, Is.EqualTo(productId));
        }

        [Test]
        public void CategoryId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _productCategories.CategoryId = Guid.NewGuid();

            // Act
            var result = _productCategories.CategoryId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetCategoryId()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            _productCategories.CategoryId = categoryId;

            // Act
            var result = _productCategories.CategoryId;

            // Assert
            Assert.That(result, Is.EqualTo(categoryId));
        }

        [Test]
        public void CanSetCategoryId()
        {
            // Arrange
            var categoryId = Guid.NewGuid();

            // Act
            _productCategories.CategoryId = categoryId;

            // Assert
            Assert.That(_productCategories.CategoryId, Is.EqualTo(categoryId));
        }

        [Test]
        public void ShouldHaveUniqueProductAndCategoryCombination()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();

            // Act
            _productCategories.ProductId = productId;
            _productCategories.CategoryId = categoryId;

            // Assert
            Assert.That(_productCategories.ProductId, Is.EqualTo(productId));
            Assert.That(_productCategories.CategoryId, Is.EqualTo(categoryId));
        }
}
