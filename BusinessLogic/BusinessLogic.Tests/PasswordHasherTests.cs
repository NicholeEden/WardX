using BusinessLogic.Security;
using Xunit;

namespace BusinessLogic.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void Matching_PasswordHash()
        {
            // instantiate the 'WARDxPasswordHasher' class
            var hasher = new WARDxPasswordHasher();
            // make the method call
            var passwordHash = hasher.Hash("1234");
            // assert that the result was a valid hash
            Assert.True(hasher.Verify("1234", passwordHash));
        }

        [Fact]
        public void Valid_PasswordHash()
        {
            // instantiate the 'WARDxPasswordHasher' class
            var hasher = new WARDxPasswordHasher();
            // make the method call
            var passwordHash = hasher.Hash("1234");
            // assert that the result was a supported hash
            Assert.True(hasher.IsHashSupported(passwordHash));
        }
    }
}
