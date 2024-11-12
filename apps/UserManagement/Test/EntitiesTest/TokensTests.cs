using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class TokensTests
{
    private SessionToken _token;

        [SetUp]
        public void SetUp()
        {
            _token = new SessionToken();
        }

        [Test]
        public void UserId_ShouldBeOfTypeGuid()
        {
            _token.UserId = Guid.NewGuid();
            Assert.IsInstanceOf<Guid>(_token.UserId);
        }

        [Test]
        public void ShouldSetAndGetToken()
        {
            _token.Token = "sampleToken123";
            Assert.That(_token.Token, Is.EqualTo("sampleToken123"));
        }

        [Test]
        public void ShouldSetAndGetUserId()
        {
            var userId = Guid.NewGuid();
            _token.UserId = userId;
            Assert.That(_token.UserId, Is.EqualTo(userId));
        }

        [Test]
        public void Token_ShouldHaveValidFormat()
        {
            _token.Token = "ValidToken123";
            bool isValidFormat = _token.Token.Length >= 6 && _token.Token.Length <= 10000;
            Assert.IsTrue(isValidFormat, "Token format is invalid.");
        }

        [Test]
        public void UserId_ShouldNotBeEmpty()
        {
            _token.UserId = Guid.NewGuid();
            Assert.That(_token.UserId, Is.Not.EqualTo(Guid.Empty), "UserId should not be Guid.Empty.");
        }
}