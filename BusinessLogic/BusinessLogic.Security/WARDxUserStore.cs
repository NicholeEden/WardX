using BusinessLogic.Interface;
using DataAccess.Interface;
using EFCore.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Security
{
    public class WARDxUserStore :
        IUserStore<WARDxUser>,
        IUserRoleStore<WARDxUser>,
        IUserPasswordStore<WARDxUser>,
        IPasswordHasher<WARDxUser>
    {
        private readonly IDatabaseAccess databaseAccess;
        private readonly IDataProvider dataProvider;
        private readonly IWARDxPasswordHasher passwordHasher;

        public WARDxUserStore(IDataProvider dataProvider,
            IWARDxPasswordHasher passwordHasher)
        {
            this.databaseAccess = ScopeProvider.DataAccessScope();
            this.dataProvider = dataProvider;
            this.passwordHasher = passwordHasher;
        }

        public Task AddToRoleAsync(WARDxUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(AddToRoleAsync));
        }

        public Task<IdentityResult> CreateAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(CreateAsync));
        }

        public Task<IdentityResult> DeleteAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(DeleteAsync));
        }

        public void Dispose()
        {
            // TODO: unknown implementation
            return;
        }

        public async Task<WARDxUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindUserByID(int.Parse(userId)));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to 'WARDxUser' class instance
                return dataProvider.GetClassFromTable<WARDxUser>(table);
            }
            return null;
        }

        public async Task<WARDxUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindUserByName(normalizedUserName));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to 'WARDxUser' class instance
                return dataProvider.GetClassFromTable<WARDxUser>(table);
            }
            return null;
        }

        public Task<string> GetNormalizedUserNameAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // return the value in 'FirstName'
            return Task.FromResult(user.FirstName);
        }

        public Task<string> GetPasswordHashAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // return the value in 'PasswordHash'
            return Task.FromResult(user.PasswordHash);
        }

        public async Task<IList<string>> GetRolesAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindRoleByUserID(user.UserID));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to  a 'List<string>'
                return dataProvider.GetColumnData(table, nameof(IRole.RoleName));
            }
            return null;
        }

        public Task<string> GetUserIdAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // return the value in 'UserID'
            return Task.FromResult(user.UserID.ToString());
        }

        public Task<string> GetUserNameAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // return the value in 'UserName'
            return Task.FromResult(user.UserName);
        }

        public async Task<IList<WARDxUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindUserByRoleName(roleName));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to  a 'List<WARDxUser>'
                return dataProvider.GetClassListFromTable<WARDxUser>(table);
            }
            return null;
        }

        public string HashPassword(WARDxUser user, string password)
        {
            // hash the plain text password
            return passwordHasher.Hash(password);
        }

        public Task<bool> HasPasswordAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            // verify if the property 'PasswordHash' has a value
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash) == false);
        }

        public async Task<bool> IsInRoleAsync(WARDxUser user, string roleName, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindUserByRoleName(roleName));
            // if result returned a table
            if (table != null)
            {
                // iterate through each row in the table
                foreach (DataRow row in table.Rows)
                {
                    // if the value in the table matches the one in the 'WARDxUser' instance
                    if ((int)row["UserID"] == user.UserID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Task RemoveFromRoleAsync(WARDxUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(RemoveFromRoleAsync));
        }

        public Task SetNormalizedUserNameAsync(WARDxUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetNormalizedUserNameAsync));
        }

        public Task SetPasswordHashAsync(WARDxUser user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetPasswordHashAsync));
            //TODO: Implement methods for SetPasswordHashAsync
        }

        public Task SetUserNameAsync(WARDxUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetUserNameAsync));
        }

        public Task<IdentityResult> UpdateAsync(WARDxUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(UpdateAsync));
        }

        public PasswordVerificationResult VerifyHashedPassword(WARDxUser user, string hashedPassword, string providedPassword)
        {
            // if hashed password is supported
            if (passwordHasher.IsHashSupported(hashedPassword))
            {
                // if hashed password is a match with what was provided
                if (passwordHasher.Verify(providedPassword, hashedPassword))
                {
                    return PasswordVerificationResult.Success;
                }
            }
            return PasswordVerificationResult.Failed;
        }
    }
}