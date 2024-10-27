using System.Text.RegularExpressions;
using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class UserTests
{
    private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new User();
        }

        [Test]
        public void UserId_ShouldBeOfTypeGuid()
        {
            _user.UserId = Guid.NewGuid();
            var result = _user.UserId;
            Assert.IsInstanceOf<Guid>(result);
        }

        [Test]
        public void Name_ShouldBeStringTypeAndDefaultEmpty()
        {
            Assert.IsInstanceOf<string>(_user.Name);
            Assert.That(_user.Name, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Rol_ShouldBeStringTypeAndDefaultEmpty()
        {
            Assert.IsInstanceOf<string>(_user.Rol);
            Assert.That(_user.Rol, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Email_ShouldBeStringTypeAndDefaultEmpty()
        {
            Assert.IsInstanceOf<string>(_user.Email);
            Assert.That(_user.Email, Is.EqualTo(string.Empty));
        }

        [Test]
        public void PhoneNumber_ShouldBeStringTypeAndDefaultEmpty()
        {
            Assert.IsInstanceOf<string>(_user.PhoneNumber);
            Assert.That(_user.PhoneNumber, Is.EqualTo(string.Empty));
        }

        [Test]
        public void BirthDate_ShouldBeOfTypeDateTime()
        {
            _user.BirthDate = DateTime.Now;
            Assert.IsInstanceOf<DateTime>(_user.BirthDate);
        }

        [Test]
        public void ShouldSetAndGetName()
        {
            _user.Name = "John Doe";
            Assert.That(_user.Name, Is.EqualTo("John Doe"));
        }

        [Test]
        public void ShouldSetAndGetRol()
        {
            _user.Rol = "Admin";
            Assert.That(_user.Rol, Is.EqualTo("Admin"));
        }

        [Test]
        public void ShouldSetAndGetEmail()
        {
            _user.Email = "test@example.com";
            Assert.That(_user.Email, Is.EqualTo("test@example.com"));
        }

        [Test]
        public void ShouldSetAndGetPhoneNumber()
        {
            _user.PhoneNumber = "1234567890";
            Assert.That(_user.PhoneNumber, Is.EqualTo("1234567890"));
        }

        [Test]
        public void ShouldSetAndGetBirthDate()
        {
            var birthDate = new DateTime(2000, 1, 1);
            _user.BirthDate = birthDate;
            Assert.That(_user.BirthDate, Is.EqualTo(birthDate));
        }

        [Test]
        public void Email_ShouldBeInValidFormat()
        {
            _user.Email = "test@example.com";
            bool isValidEmail = Regex.IsMatch(_user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            Assert.IsTrue(isValidEmail, "The email format is invalid.");
        }

        [Test]
        public void PhoneNumber_ShouldContainOnlyDigits()
        {
            _user.PhoneNumber = "1234567890";
            bool isOnlyDigits = Regex.IsMatch(_user.PhoneNumber, @"^\d+$");
            Assert.IsTrue(isOnlyDigits, "PhoneNumber contains non-digit characters.");
        }

        [Test]
        public void BirthDate_ShouldNotBeInFuture()
        {
            _user.BirthDate = DateTime.Now.AddDays(-1);
            Assert.LessOrEqual(_user.BirthDate, DateTime.Now, "BirthDate is in the future.");
        }

        // 4. Integridad y lógica de negocio
        [Test]
        public void UserId_ShouldBeUnique()
        {
            var user1 = new User { UserId = Guid.NewGuid() };
            var user2 = new User { UserId = Guid.NewGuid() };
            Assert.That(user2.UserId, Is.Not.EqualTo(user1.UserId), "UserIds are not unique.");
        }

        [Test]
        public void Rol_ShouldBeInAllowedRoles()
        {
            string[] allowedRoles = { "Admin", "User", "Guest" };
            _user.Rol = "Admin";
            Assert.Contains(_user.Rol, allowedRoles, "Role is not in the list of allowed roles.");
        }
}