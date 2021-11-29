using Autofac;
using DataAccess;
using DataAccess.Interface;

namespace BusinessLogic
{
    public static class ScopeProvider
    {
        public static IDatabaseAccess DataAccessScope()
        {
            // provides the dependency injection container for the Data Access Layer
            var container = DataAccessConfig.Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<IDatabaseAccess>();
        }
    }
}