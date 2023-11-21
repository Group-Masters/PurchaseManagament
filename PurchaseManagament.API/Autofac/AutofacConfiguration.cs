using Autofac;
using Autofac.Extras.DynamicProxy;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Services;

namespace PurchaseManagament.API.Autofac
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyService>().As<ICompanyService>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingInterceptor));
            builder.Register(c => new LoggingInterceptor());
        }
    }
}
