using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class StockTests
{
    private Stock _stock;

        [SetUp]
        public void SetUp()
        {
            _stock = new Stock();
        }

        [Test]
        public void StockId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _stock.StockId = Guid.NewGuid();

            // Act
            var result = _stock.StockId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetStockId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _stock.StockId = id;

            // Act
            var result = _stock.StockId;

            // Assert
            Assert.That(id, Is.EqualTo(result));
        }

        [Test]
        public void CanSetStockId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _stock.StockId = id;

            // Assert
            Assert.That(_stock.StockId, Is.EqualTo(id));
        }

        [Test]
        public void Code_ShouldBeOfTypeInt()
        {
            // Arrange
            _stock.Code = 54321;

            // Act
            var result = _stock.Code;

            // Assert
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void CanGetCode()
        {
            // Arrange
            var code = 54321;
            _stock.Code = code;

            // Act
            var result = _stock.Code;

            // Assert
            Assert.That(result, Is.EqualTo(code));
        }

        [Test]
        public void CanSetCode()
        {
            // Arrange
            var code = 54321;

            // Act
            _stock.Code = code;

            // Assert
            Assert.That(_stock.Code, Is.EqualTo(code));
        }

        [Test]
        public void Quantity_ShouldBeOfTypeInt()
        {
            // Arrange
            _stock.Quantity = 100;

            // Act
            var result = _stock.Quantity;

            // Assert
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void CanGetQuantity()
        {
            // Arrange
            var quantity = 100;
            _stock.Quantity = quantity;

            // Act
            var result = _stock.Quantity;

            // Assert
            Assert.That(result, Is.EqualTo(quantity));
        }

        [Test]
        public void CanSetQuantity()
        {
            // Arrange
            var quantity = 100;

            // Act
            _stock.Quantity = quantity;

            // Assert
            Assert.That(_stock.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        public void ProductId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _stock.ProductId = Guid.NewGuid();

            // Act
            var result = _stock.ProductId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetProductId()
        {
            // Arrange
            var productId = Guid.NewGuid();
            _stock.ProductId = productId;

            // Act
            var result = _stock.ProductId;

            // Assert
            Assert.That(result, Is.EqualTo(productId));
        }

        [Test]
        public void CanSetProductId()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            _stock.ProductId = productId;

            // Assert
            Assert.That(_stock.ProductId, Is.EqualTo(productId));
        }

        [Test]
        public void SubsidiaryId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _stock.SubsidiaryId = Guid.NewGuid();

            // Act
            var result = _stock.SubsidiaryId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetSubsidiaryId()
        {
            // Arrange
            var subsidiaryId = Guid.NewGuid();
            _stock.SubsidiaryId = subsidiaryId;

            // Act
            var result = _stock.SubsidiaryId;

            // Assert
            Assert.That(result, Is.EqualTo(subsidiaryId));
        }

        [Test]
        public void CanSetSubsidiaryId()
        {
            // Arrange
            var subsidiaryId = Guid.NewGuid();

            // Act
            _stock.SubsidiaryId = subsidiaryId;

            // Assert
            Assert.That(_stock.SubsidiaryId, Is.EqualTo(subsidiaryId));
        }
}
