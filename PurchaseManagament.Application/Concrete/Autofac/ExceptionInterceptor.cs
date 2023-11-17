using Castle.DynamicProxy;

namespace PurchaseManagament.Application.Autofac
{
    public class ExceptionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
