using SmartFleet.Business;
using SmartFleet.Core.BusinessContracts;
using SmartFleet.Core.DataContracts;
using SmartFleet.Data;
using SmartFleet.Database;
using SmartFleet.Database.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmartFleet.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SmartFleet.Web.App_Start.NinjectWebCommon), "Stop")]

namespace SmartFleet.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<SmartFleetContext>().To<SmartFleetContext>().InRequestScope();
            kernel.Bind<IRouteRepository>().To<RouteRepository>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();

        }        
    }
}
