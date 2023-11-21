using Autofac;
using Autofac.Extras.DynamicProxy;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.UnitWork;

namespace PurchaseManagament.API.Autofac
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitWork>().As<IUnitWork>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingInterceptor), typeof(ExceptionHandlingInterceptor));

            builder.RegisterType<CompanyService>().As<ICompanyService>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionHandlingInterceptor));

            builder.Register(c => new ExceptionHandlingInterceptor());
            builder.Register(c => new LoggingInterceptor());
        }
    }
}
