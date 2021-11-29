using BusinessLogic.Security;
using System.Threading;
using Xunit;

namespace BusinessLogic.Tests
{
    public class Auth_Tests
    {
        [Fact(Skip ="No database connection")]
        public void IsInRoleAsync_GP()
        {
            var userStore = new WARDxUserStore(new DataProvider(), new WARDxPasswordHasher());

            var user = new WARDxUser { UserID = 101 };

            var result = userStore.IsInRoleAsync(user, "General Practitioner", CancellationToken.None);

            Assert.True(result.Result);
        }

        [Fact(Skip = "No database connection")]
        public void GetRolesAsync()
        {
            var userStore = new WARDxUserStore(new DataProvider(), new WARDxPasswordHasher());

            var user = new WARDxUser { UserID = 101 };

            var result = userStore.GetRolesAsync(user, CancellationToken.None);

            Assert.True(result.Result.Contains("General Practitioner"));
        }
    }
}
