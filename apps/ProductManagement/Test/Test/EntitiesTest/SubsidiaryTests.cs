using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class SubsidiaryTests
{
    private Subsidiary _subsidiary;

        [SetUp]
        public void SetUp()
        {
            _subsidiary = new Subsidiary();
        }

        [Test]
        public void SubsidiaryId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _subsidiary.SubsidiaryId = Guid.NewGuid();

            // Act
            var result = _subsidiary.SubsidiaryId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetSubsidiaryId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _subsidiary.SubsidiaryId = id;

            // Act
            var result = _subsidiary.SubsidiaryId;

            // Assert
            Assert.That(result, Is.EqualTo(id));
        }

        [Test]
        public void CanSetSubsidiaryId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _subsidiary.SubsidiaryId = id;

            // Assert
            Assert.That(_subsidiary.SubsidiaryId, Is.EqualTo(id));
        }

        [Test]
        public void Latitude_ShouldBeOfTypeDecimal()
        {
            // Arrange
            _subsidiary.Latitude = 40.7128m;

            // Act
            var result = _subsidiary.Latitude;

            // Assert
            Assert.IsInstanceOf<decimal>(result);
        }

        [Test]
        public void CanGetLatitude()
        {
            // Arrange
            var latitude = 40.7128m;
            _subsidiary.Latitude = latitude;

            // Act
            var result = _subsidiary.Latitude;

            // Assert
            Assert.That(result, Is.EqualTo(latitude));
        }

        [Test]
        public void CanSetLatitude()
        {
            // Arrange
            var latitude = 40.7128m;

            // Act
            _subsidiary.Latitude = latitude;

            // Assert
            Assert.That(_subsidiary.Latitude, Is.EqualTo(latitude));
        }

        [Test]
        public void Longitude_ShouldBeOfTypeDecimal()
        {
            // Arrange
            _subsidiary.Longitude = -74.0060m;

            // Act
            var result = _subsidiary.Longitude;

            // Assert
            Assert.IsInstanceOf<decimal>(result);
        }

        [Test]
        public void CanGetLongitude()
        {
            // Arrange
            var longitude = -74.0060m;
            _subsidiary.Longitude = longitude;

            // Act
            var result = _subsidiary.Longitude;

            // Assert
            Assert.That(result, Is.EqualTo(longitude));
        }

        [Test]
        public void CanSetLongitude()
        {
            // Arrange
            var longitude = -74.0060m;

            // Act
            _subsidiary.Longitude = longitude;

            // Assert
            Assert.That(_subsidiary.Longitude, Is.EqualTo(longitude));
        }

        [Test]
        public void Name_ShouldBeOfTypeString()
        {
            // Arrange
            _subsidiary.Name = "Main Office";

            // Act
            var result = _subsidiary.Name;

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void CanGetName()
        {
            // Arrange
            var name = "Main Office";
            _subsidiary.Name = name;

            // Act
            var result = _subsidiary.Name;

            // Assert
            Assert.That(result, Is.EqualTo(name));
        }

        [Test]
        public void CanSetName()
        {
            // Arrange
            var name = "Main Office";

            // Act
            _subsidiary.Name = name;

            // Assert
            Assert.That(_subsidiary.Name, Is.EqualTo(name));
        }

        [Test]
        public void Type_ShouldBeOfTypeString()
        {
            // Arrange
            _subsidiary.Type = "Warehouse";

            // Act
            var result = _subsidiary.Type;

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void CanGetType()
        {
            // Arrange
            var type = "Warehouse";
            _subsidiary.Type = type;

            // Act
            var result = _subsidiary.Type;

            // Assert
            Assert.That(result, Is.EqualTo(type));
        }

        [Test]
        public void CanSetType()
        {
            // Arrange
            var type = "Warehouse";

            // Act
            _subsidiary.Type = type;

            // Assert
            Assert.That(_subsidiary.Type, Is.EqualTo(type));
        }

        [Test]
        public void CompanyId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _subsidiary.CompanyId = Guid.NewGuid();

            // Act
            var result = _subsidiary.CompanyId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetCompanyId()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            _subsidiary.CompanyId = companyId;

            // Act
            var result = _subsidiary.CompanyId;

            // Assert
            Assert.That(result, Is.EqualTo(companyId));
        }

        [Test]
        public void CanSetCompanyId()
        {
            // Arrange
            var companyId = Guid.NewGuid();

            // Act
            _subsidiary.CompanyId = companyId;

            // Assert
            Assert.That(_subsidiary.CompanyId, Is.EqualTo(companyId));
        }
}
