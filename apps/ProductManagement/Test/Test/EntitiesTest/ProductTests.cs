using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class ProductTests
{
    private Product _product;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
        }

        [Test]
        public void ProductId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _product.ProductId = Guid.NewGuid();

            // Act
            var result = _product.ProductId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetProductId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _product.ProductId = id;

            // Act
            var result = _product.ProductId;

            // Assert
            Assert.That(result, Is.EqualTo(id));
        }

        [Test]
        public void CanSetProductId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _product.ProductId = id;

            // Assert
            Assert.That(_product.ProductId, Is.EqualTo(id));
        }

        [Test]
        public void Name_ShouldBeOfTypeString()
        {
            // Arrange
            _product.Name = "Laptop";

            // Act
            var result = _product.Name;

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void CanGetName()
        {
            // Arrange
            var name = "Laptop";
            _product.Name = name;

            // Act
            var result = _product.Name;

            // Assert
            Assert.That(result, Is.EqualTo(name));
        }

        [Test]
        public void CanSetName()
        {
            // Arrange
            var name = "Laptop";

            // Act
            _product.Name = name;

            // Assert
            Assert.That(_product.Name, Is.EqualTo(name));
        }

        [Test]
        public void IncomingPrice_ShouldBeOfTypeDecimal()
        {
            // Arrange
            _product.IncomingPrice = 1000.50m;

            // Act
            var result = _product.IncomingPrice;

            // Assert
            Assert.IsInstanceOf<decimal>(result);
        }

        [Test]
        public void CanGetIncomingPrice()
        {
            // Arrange
            var price = 1000.50m;
            _product.IncomingPrice = price;

            // Act
            var result = _product.IncomingPrice;

            // Assert
            Assert.That(result, Is.EqualTo(price));
        }

        [Test]
        public void CanSetIncomingPrice()
        {
            // Arrange
            var price = 1000.50m;

            // Act
            _product.IncomingPrice = price;

            // Assert
            Assert.That(_product.IncomingPrice, Is.EqualTo(price));
        }

        [Test]
        public void Code_ShouldBeOfTypeInt()
        {
            // Arrange
            _product.Code = 12345;

            // Act
            var result = _product.Code;

            // Assert
            Assert.IsInstanceOf<int>(result);
        }

        [Test]
        public void CanGetCode()
        {
            // Arrange
            var code = 12345;
            _product.Code = code;

            // Act
            var result = _product.Code;

            // Assert
            Assert.That(result, Is.EqualTo(code));
        }

        [Test]
        public void CanSetCode()
        {
            // Arrange
            var code = 12345;

            // Act
            _product.Code = code;

            // Assert
            Assert.That(_product.Code, Is.EqualTo(code));
        }

        [Test]
        public void SellPrice_ShouldBeOfTypeDecimal()
        {
            // Arrange
            _product.SellPrice = 1500.75m;

            // Act
            var result = _product.SellPrice;

            // Assert
            Assert.IsInstanceOf<decimal>(result);
        }

        [Test]
        public void CanGetSellPrice()
        {
            // Arrange
            var sellPrice = 1500.75m;
            _product.SellPrice = sellPrice;

            // Act
            var result = _product.SellPrice;

            // Assert
            Assert.That(result, Is.EqualTo(sellPrice));
        }

        [Test]
        public void CanSetSellPrice()
        {
            // Arrange
            var sellPrice = 1500.75m;

            // Act
            _product.SellPrice = sellPrice;

            // Assert
            Assert.That(_product.SellPrice, Is.EqualTo(sellPrice));
        }

        [Test]
        public void CompanyId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _product.CompanyId = Guid.NewGuid();

            // Act
            var result = _product.CompanyId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetCompanyId()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            _product.CompanyId = companyId;

            // Act
            var result = _product.CompanyId;

            // Assert
            Assert.That(result, Is.EqualTo(companyId));
        }

        [Test]
        public void CanSetCompanyId()
        {
            // Arrange
            var companyId = Guid.NewGuid();

            // Act
            _product.CompanyId = companyId;

            // Assert
            Assert.That(_product.CompanyId, Is.EqualTo(companyId));
        }
}
