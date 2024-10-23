using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class CategoryTests
{
    private Category _category;

        [SetUp]
        public void SetUp()
        {
            _category = new Category();
        }

        [Test]
        public void CategoryId_ShouldBeOfTypeGuid()
        {
            // Arrange
            _category.CategoryId = Guid.NewGuid();

            // Act
            var result = _category.CategoryId;

            // Assert
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void CanGetCategoryId()
        {
            // Arrange
            var id = Guid.NewGuid();
            _category.CategoryId = id;

            // Act
            var result = _category.CategoryId;

            // Assert
            Assert.That(result, Is.EqualTo(id));
        }

        [Test]
        public void CanSetCategoryId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _category.CategoryId = id;

            // Assert
            Assert.That(_category.CategoryId, Is.EqualTo(id));
        }

        [Test]
        public void Name_ShouldBeOfTypeString()
        {
            // Arrange
            _category.Name = "Electronics";

            // Act
            var result = _category.Name;

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        public void CanGetName()
        {
            // Arrange
            var name = "Electronics";
            _category.Name = name;

            // Act
            var result = _category.Name;

            // Assert
            Assert.That(result, Is.EqualTo(name));
        }

        [Test]
        public void CanSetName()
        {
            // Arrange
            var name = "Electronics";

            // Act
            _category.Name = name;

            // Assert
            Assert.That(_category.Name, Is.EqualTo(name));
        }

        [Test]
        public void Name_ShouldNotBeNullOrEmpty()
        {
            // Arrange
            _category.Name = "Electronics";

            // Act & Assert
            Assert.IsFalse(string.IsNullOrEmpty(_category.Name));
        }
    
}
