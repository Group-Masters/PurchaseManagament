using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string logFilePath;

        public RequestLoggingMiddleware(RequestDelegate next, string logFilePath)
        {
            _next = next;
            this.logFilePath = logFilePath;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // İstekin geldiği IP adresini alın
            var clientIpAddress = context.Connection.RemoteIpAddress;

            // İstekin geldiği zamanı alın
            var requestTime = DateTime.Now;

            // İsteği loglamak için bilgileri oluşturun
            string logInfo = $"{requestTime.ToString("yyyy-MM-dd HH:mm:ss")} - IP: {clientIpAddress}, Request: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}";

            // İsteği sonraki middleware'e iletmek için _next'i çağırın
            await _next(context);

            // İstek başarılı ise başarılı olduğunu loglayın
            if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300)
            {
                logInfo += " - SUCCESS";
            }
            // İstek başarısız ise başarısız olduğunu loglayın
            else
            {
                logInfo += " - FAILED";
            }

            logInfo += "\n";

            // Log bilgilerini dosyaya yazın
            await LogRequest(logInfo);
        }

        private async Task LogRequest(string logInfo)
        {
            try
            {
                await File.AppendAllTextAsync(logFilePath, logInfo, Encoding.UTF8);
            }
            catch (IOException)
            {
                // Hata durumlarını ele almak için buraya kod ekleyebilirsiniz
            }
        }
    }

    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder builder, string logFilePath)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>(logFilePath);
        }
    }
}
