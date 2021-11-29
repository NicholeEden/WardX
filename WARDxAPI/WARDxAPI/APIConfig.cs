using Autofac;
using System.Reflection;
using WARDxAPI.Interface;
using WARDxAPI.Model;
using WARDxAPI.Model.Interface;
using WARDxAPI.Models;

namespace WARDxAPI
{
    /// <summary>
    /// This class configures the dependency injection using Autofac
    /// </summary>
    public static class APIConfig
    {
        /// <summary>
        /// Creates the container that registers the assemblies 'WARDxAPI.Model' and 'WARDxAPI.Model.Shared'
        /// </summary>
        /// <returns></returns>
        private static IContainer Container()
        {
            var builder = new ContainerBuilder();

            // Loads all classes in DataAccess.Domain and replaces the implemented interfaces
            // with the classes
            builder.RegisterAssemblyTypes(Assembly.Load("WARDxAPI.Model"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.Load("WARDxAPI.Model.Shared"))
                   .AsImplementedInterfaces();

            builder.RegisterType<ProfileModelProvider>().AsImplementedInterfaces();

            builder.RegisterType<PatientMoveModelProvider>().AsImplementedInterfaces();

            builder.RegisterType<AdmissionModelProvider>().AsImplementedInterfaces();
            
            builder.RegisterType<SchedulingModelProvider>().AsImplementedInterfaces();

            builder.RegisterType<TreatmentModelProvider>().AsImplementedInterfaces();

            return builder.Build();
        }

        /// <summary>
        /// Resolves the implementation for the interface 'IAlertModel'
        /// </summary>
        /// <returns></returns>
        public static IAlertModel ResolveAlertModel()
        {
            // provides the dependency injection container for the Alert Model
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<IAlertModel>();
        }

        /// <summary>
        /// Resolves all the implementations for the interface 'IPatientProfileProvider'
        /// </summary>
        /// <returns></returns>
        public static IProfileModelProvider ResolvePatientProfileModel()
        {
            // provides the dependency injection container for the Patient Profile models
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<IProfileModelProvider>();
        }
        /// <summary>
        /// Resolves all the implementations for the interface 'IPatientMoveProvider'
        /// </summary>
        /// <returns></returns>
        /// 

        public static ISchedulingModelProvider ResolveSchedulingModel()
        {
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<ISchedulingModelProvider>();
        }

        public static IPatientMoveModelProvider ResolvePatientMoveModel()
        {
            // provides the dependency injection container for the Patient Movement models
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<IPatientMoveModelProvider>();
        }

        /// <summary>
        /// Resolves all the implementations for the interface 'AdmissionProvider'
        /// </summary>
        /// <returns></returns>
        public static IAdmissionModelProvider ResolveAdmissionModel()
        {
            // provides the dependency injection container for the Admission models
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<IAdmissionModelProvider>();
        }

        /// <summary>
        /// Resolves all the implementations for the interface 'ITreatmentProvider'
        /// </summary>
        /// <returns></returns>
        public static ITreatmentModelProvider ResolveTreatmentModel()
        {
            // provides the dependency injection container for the treatment models
            var container = Container();
            var scope = container.BeginLifetimeScope();
            return scope.Resolve<ITreatmentModelProvider>();
        }
    }
}
