using ArxOne.MrAdvice.Advice;
using Castle.DynamicProxy;
using KingAOP.Aspects;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using Serilog;
using System.Reflection;
using System.Text;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class ExceptionHandlingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }catch(Exception ex)
            {
                
            }
        }
    }
}
