using Autofac;
using Autofac.Extras.DynamicProxy;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.UnitWork;

namespace PurchaseManagament.Application.Concrete.Inteceptors
{
    public class AutoFacİnterceptor : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyOpenGenericTypes();

            builder.RegisterType<UnitWork>().As<IUnitWork>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(ExceptionHandlingInterceptor));

            builder.Register(c => new ExceptionHandlingInterceptor());
        }
    }
}
