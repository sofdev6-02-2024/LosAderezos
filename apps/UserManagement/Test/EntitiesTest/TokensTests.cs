using Backend.Entities;

namespace Test.EntitiesTest;

[TestFixture]
public class TokensTests
{
    private Tokens _token;

        [SetUp]
        public void SetUp()
        {
            _token = new Tokens();
        }

        [Test]
        public void TokenId_ShouldBeOfTypeGuid()
        {
            _token.TokenId = Guid.NewGuid();
            Assert.IsInstanceOf<Guid>(_token.TokenId);
        }

        [Test]
        public void Token_ShouldBeStringTypeAndDefaultEmpty()
        {
            Assert.IsInstanceOf<string>(_token.Token);
            Assert.That(_token.Token, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CreationDate_ShouldBeOfTypeDateTime()
        {
            _token.CreationDate = DateTime.Now;
            Assert.IsInstanceOf<DateTime>(_token.CreationDate);
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
        public void ShouldSetAndGetCreationDate()
        {
            var date = new DateTime(2023, 10, 26);
            _token.CreationDate = date;
            Assert.That(_token.CreationDate, Is.EqualTo(date));
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
            bool isValidFormat = _token.Token.Length >= 6 && _token.Token.Length <= 128;
            Assert.IsTrue(isValidFormat, "Token format is invalid.");
        }

        [Test]
        public void CreationDate_ShouldNotBeInFuture()
        {
            _token.CreationDate = DateTime.Now.AddMinutes(-1);
            Assert.LessOrEqual(_token.CreationDate, DateTime.Now, "CreationDate is in the future.");
        }

        [Test]
        public void UserId_ShouldNotBeEmpty()
        {
            _token.UserId = Guid.NewGuid();
            Assert.That(_token.UserId, Is.Not.EqualTo(Guid.Empty), "UserId should not be Guid.Empty.");
        }

        [Test]
        public void TokenId_ShouldBeUnique()
        {
            var token1 = new Tokens { TokenId = Guid.NewGuid() };
            var token2 = new Tokens { TokenId = Guid.NewGuid() };
            Assert.That(token2.TokenId, Is.Not.EqualTo(token1.TokenId), "TokenId is not unique.");
        }
}