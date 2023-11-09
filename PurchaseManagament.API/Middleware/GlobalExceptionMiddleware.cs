using Serilog;
using ILogger = Serilog.ILogger;

namespace PurchaseManagament.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _request; // requestleri handle etmek için RequestDelegate classından yararlanacağız
        private static readonly ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>(); // ILogger interface’ini implement etmiş bir Logger örneği verecek.

        public GlobalExceptionMiddleware(RequestDelegate request) 
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try // Kullanıcı tarafından bir request gelir ve request middleware’imizdeki try-catch tarafından kontrollü olarak değerlendirmeye alınır.
            {
                await _request(httpContext);
            }
            catch (Exception ex) // Bu değerlendirme sırasında kodumuz hataya düşer ve catch bloğumuz bu hatayı loglaması için HandleExceptionAsync metodunu çağırır ve hata loglanır.
            {
                // Kalabalığı engellemek için hata logic'ini bir metoda taşıyorum.
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.Error($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");

            return Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
