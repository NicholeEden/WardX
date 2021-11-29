using BusinessLogic.Interface;
using DataAccess.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Security
{
    public class WARDxRoleStore :
        IRoleStore<WARDxRole>
    {
        private readonly IDatabaseAccess databaseAccess;
        private readonly IDataProvider dataProvider;

        public WARDxRoleStore(IDataProvider dataProvider)
        {
            this.databaseAccess = ScopeProvider.DataAccessScope();
            this.dataProvider = dataProvider;
        }

        public Task<IdentityResult> CreateAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(CreateAsync));
        }

        public Task<IdentityResult> DeleteAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(DeleteAsync));
        }

        public void Dispose()
        {
            return;
        }

        public async Task<WARDxRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindRoleByID(int.Parse(roleId)));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to 'WARDxUser' class instance
                return dataProvider.GetClassFromTable<WARDxRole>(table);
            }
            return null;
        }

        public async Task<WARDxRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            // call the data access layer method and await the result
            var table = await Task.FromResult(databaseAccess.Auth_FindRoleByName(normalizedRoleName));
            // if result returned a table
            if (table != null)
            {
                // convert DataTable to 'WARDxUser' class instance
                return dataProvider.GetClassFromTable<WARDxRole>(table);
            }
            return null;
        }

        public Task<string> GetNormalizedRoleNameAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            // return the value in 'RoleName'
            return Task.FromResult(role.RoleName);
        }

        public Task<string> GetRoleIdAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            // return the value in 'RoleID'
            return Task.FromResult(role.RoleID.ToString());
        }

        public Task<string> GetRoleNameAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            // return the value in 'RoleName'
            return Task.FromResult(role.RoleName);
        }

        public Task SetNormalizedRoleNameAsync(WARDxRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetNormalizedRoleNameAsync));
        }

        public Task SetRoleNameAsync(WARDxRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetRoleNameAsync));
        }

        public Task<IdentityResult> UpdateAsync(WARDxRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(UpdateAsync));
        }
    }
}
