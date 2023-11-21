using Castle.DynamicProxy;

namespace PurchaseManagament.Application.Concrete.Inteceptors
{
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
			try
			{
                invocation.Proceed();
			}
			catch			
            {
                throw new Exception("Arka planda bir şeyler ters gitti");
            }
        }
    }
}
