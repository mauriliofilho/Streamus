[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Streamus.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Streamus.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Streamus.Web.App_Start
{
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Streamus.Data;
	using Streamus.Web.Infrastructure.Caching;
	using Streamus.Web.Infrastructure.Populators;
	using Streamus.Web.Infrastructure.Services;
	using Streamus.Web.Infrastructure.Services.Contracts;
	using System;
	using System.Data.Entity;
	using System.Web;

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
			// Database
			kernel.Bind<DbContext>().To<StreamusDbContext>();
			kernel.Bind<IStreamusData>().To<StreamusData>();

			// Caching
			kernel.Bind<ICacheService>().To<InMemoryCache>();

			// Services
			kernel.Bind<IHomeServices>().To<HomeServices>();
			kernel.Bind<ISearchServices>().To<SearchServices>();

			// Populators
			kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();
		}
	}
}