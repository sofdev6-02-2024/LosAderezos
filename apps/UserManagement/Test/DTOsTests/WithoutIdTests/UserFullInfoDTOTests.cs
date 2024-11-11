using Backend.DTOs.WithoutID;

namespace Test.DTOsTests.WithoutIdTests;

[TestFixture]
public class UserFullInfoDTOTests
{
    [Test]
        public void UserFullInfoDTO_Should_SetAndGetUserIdProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var userId = Guid.NewGuid();

            // Act
            dto.UserId = userId;

            // Assert
            Assert.That(dto.UserId, Is.EqualTo(userId));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetNameProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var name = "John Doe";

            // Act
            dto.Name = name;

            // Assert
            Assert.That(dto.Name, Is.EqualTo(name));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetRolProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var rol = "Admin";

            // Act
            dto.Rol = rol;

            // Assert
            Assert.That(dto.Rol, Is.EqualTo(rol));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetEmailProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var email = "user@example.com";

            // Act
            dto.Email = email;

            // Assert
            Assert.That(dto.Email, Is.EqualTo(email));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetPhoneNumberProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var phoneNumber = "1234567890";

            // Act
            dto.PhoneNumber = phoneNumber;

            // Assert
            Assert.That(dto.PhoneNumber, Is.EqualTo(phoneNumber));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetBirthDateProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var birthDate = new DateTime(1990, 1, 1);

            // Act
            dto.BirthDate = birthDate;

            // Assert
            Assert.That(dto.BirthDate, Is.EqualTo(birthDate));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetTokenProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var token = "sampleToken";

            // Act
            dto.Token = token;

            // Assert
            Assert.That(dto.Token, Is.EqualTo(token));
        }

        [Test]
        public void UserFullInfoDTO_Should_SetAndGetTimeProperty()
        {
            // Arrange
            var dto = new UserFullInfoDTO();
            var time = DateTime.Now;

            // Act
            dto.Time = time;

            // Assert
            Assert.That(dto.Time, Is.EqualTo(time));
        }

        [Test]
        public void UserFullInfoDTO_Should_HaveDefaultValues()
        {
            // Arrange
            var dto = new UserFullInfoDTO();

            // Assert
            Assert.That(dto.UserId, Is.EqualTo(default(Guid)));
            Assert.That(dto.Name, Is.EqualTo(string.Empty));
            Assert.That(dto.Rol, Is.EqualTo(string.Empty));
            Assert.That(dto.Email, Is.EqualTo(string.Empty));
            Assert.That(dto.PhoneNumber, Is.EqualTo(string.Empty));
            Assert.That(dto.BirthDate, Is.EqualTo(default(DateTime)));
            Assert.That(dto.Token, Is.EqualTo(string.Empty));
            Assert.That(dto.Time, Is.EqualTo(default(DateTime)));
        }
}
