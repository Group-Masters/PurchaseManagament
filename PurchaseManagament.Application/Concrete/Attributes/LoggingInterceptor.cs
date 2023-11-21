using Castle.DynamicProxy;
using PurchaseManagament.Application.Concrete.Wrapper;
using Serilog;
using Serilog.Core;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var result = new Result<dynamic> { Success = false };
            Log.Information($"{invocation.Method.Name} methodu çağırıldı.");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed();
            watch.Stop();
            result.Data = invocation.ReturnValue;
            var executionTime = watch.ElapsedMilliseconds;

            Log.Information($"Result: {result.Data}");
            Console.WriteLine($"{executionTime}BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
        }
    }
}
