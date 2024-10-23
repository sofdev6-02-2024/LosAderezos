using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class CompanyTests
{
    private Company _company;

        [SetUp]
        public void SetUp()
        {
            _company = new Company();
        }

        [Test]
        public void CompanyId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _company.CompanyId = Guid.NewGuid();

            // Act
            var result = _company.CompanyId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetCompanyId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _company.CompanyId = id;

            // Act
            var result = _company.CompanyId;

            // Assert
            Assert.That(result, Is.EqualTo(id));
        }

        [Test]
        public void CanSetCompanyId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _company.CompanyId = id;

            // Assert
            Assert.That(_company.CompanyId, Is.EqualTo(id));
        }

        [Test]
        public void Name_ShouldBeOfTypeString()
        {
            // Arrange
            _company.Name = "TechCorp";

            // Act
            var result = _company.Name;

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void CanGetName()
        {
            // Arrange
            var name = "TechCorp";
            _company.Name = name;

            // Act
            var result = _company.Name;

            // Assert
            Assert.That(result, Is.EqualTo(name));
        }

        [Test]
        public void CanSetName()
        {
            // Arrange
            var name = "TechCorp";

            // Act
            _company.Name = name;

            // Assert
            Assert.That(_company.Name, Is.EqualTo(name));
        }

        [Test]
        public void UserId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _company.UserId = Guid.NewGuid();

            // Act
            var result = _company.UserId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetUserId()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _company.UserId = userId;

            // Act
            var result = _company.UserId;

            // Assert
            Assert.That(result, Is.EqualTo(userId));
        }

        [Test]
        public void CanSetUserId()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            _company.UserId = userId;

            // Assert
            Assert.That(_company.UserId, Is.EqualTo(userId));
        }

        [Test]
        public void Name_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            _company.Name = "TechCorp";

            // Act & Assert
            Assert.IsFalse(string.IsNullOrEmpty(_company.Name));
        }
}
