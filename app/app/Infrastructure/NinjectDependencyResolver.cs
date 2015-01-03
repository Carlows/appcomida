using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using app.Models;
using app.Infrastructure.Repositories;
using app.Infrastructure.Services;
using app.Providers;

namespace app.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Here you configure the bindings
            // Like this:
            //kernel.Bind<ApplicationContext>().ToSelf().InRequestScope();
            //kernel.Bind<IProductService>().To<ProductService>();
            //kernel.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();

            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IRegistroRepository>().To<RegistroRepository>().InRequestScope();
            kernel.Bind<IRegistroService>().To<RegistroService>().InRequestScope();
            kernel.Bind<IAuthRepository>().To<AuthRepository>().InRequestScope();
            kernel.Bind<IVotoRepository>().To<VotoRepository>().InRequestScope();
            kernel.Bind<SimpleAuthorizationServerProvider>().ToSelf();
        }
    }
}