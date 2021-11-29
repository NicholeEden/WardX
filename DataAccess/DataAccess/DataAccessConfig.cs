using Autofac;
using System.Reflection;

namespace DataAccess
{
    public static class DataAccessConfig
    {
        public static IContainer Container()
        {
            var builder = new ContainerBuilder();

            // Loads all classes in DataAccess.Domain and replaces the implemented interfaces
            // with the classes
            builder.RegisterAssemblyTypes(Assembly.Load("DataAccess.Domain"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("DataAccess.Manager"))
                   .AsImplementedInterfaces();

            builder.RegisterType<DatabaseAccess>().AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
