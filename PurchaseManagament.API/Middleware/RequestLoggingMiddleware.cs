using System.Security.Claims;
using System.Text;

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

            // İsteği atan kişi
            var requestBy = context.User.FindFirst(ClaimTypes.Name ?? "Anonim");

            // Request body alır
            context.Request.EnableBuffering(); //  isteğin body'sini bir tampona alır ve isteği işleyen sonraki middleware veya controller tarafından tekrar okunabilir hale getirir.
            var buffer = new byte[2048];
            var requestBody = context.Request.Body.ReadAsync(buffer , 0 , buffer.Length);
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            var requestBodyString = "";
            if (requestBody.Result > 0)
            {
                requestBodyString = Encoding.UTF8.GetString(buffer, 0, requestBody.Result);
            }

            // İstekin geldiği zamanı alın
            var requestTime = DateTime.Now;

            // İsteği loglamak için bilgileri oluşturun
            string logInfo = $"{requestTime.ToString("yyyy-MM-dd HH:mm:ss")} - IP: {clientIpAddress}, RequestBy: {requestBy?.Value.ToString() ?? "Anonim"}, Request: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}, RequestBody: {requestBodyString ?? "Null"}";

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
