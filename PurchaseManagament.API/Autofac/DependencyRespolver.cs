using Autofac;
using Autofac.Extras.DynamicProxy;
using PurchaseManagament.API.Controllers;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Autofac;
using PurchaseManagament.Application.Concrete.Services;

namespace PurchaseManagament.API.Autofac
{
    public class DependencyRespolver
    {
        private readonly IContainer _container;
        private readonly ILogger _logger;
        public DependencyRespolver()
        {
            _container = BuildContainer();
        }
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CompanyService>()
                        .As<ICompanyService>()
                        .EnableInterfaceInterceptors()
                       .InterceptedBy(typeof(ExceptionInterceptor));

            builder.RegisterType<CurrencyService>()
                        .As<ICurrencyService>()
                        .EnableInterfaceInterceptors()
                       .InterceptedBy(typeof(ExceptionInterceptor));

            builder.RegisterType<CurrencyController>()
                        .EnableInterfaceInterceptors()
                       .InterceptedBy(typeof(ExceptionInterceptor));
            return builder.Build();
        }
        public T GetService<T>()
          where T : class
        {
            var result = _container.TryResolve(out T serviceInstance);
            return serviceInstance ?? throw new Exception();
        }
    }
}
