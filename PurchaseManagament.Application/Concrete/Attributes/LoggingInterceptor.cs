using Castle.DynamicProxy;
using Serilog;
using Serilog.Core;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("AAAAAAAAAAAAA");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed();
            watch.Stop();

            var executionTime = watch.ElapsedMilliseconds;

            Log.Information($"Result: {invocation.ReturnValue}");
            Console.WriteLine($"{executionTime}BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }
    }
}
