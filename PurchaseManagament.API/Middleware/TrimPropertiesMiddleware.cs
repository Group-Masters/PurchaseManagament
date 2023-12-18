using Newtonsoft.Json.Linq;
using System.Text;

namespace PurchaseManagament.API.Middleware
{
    public class TrimPropertiesMiddleware
    {
        private readonly RequestDelegate _next;

        public TrimPropertiesMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("Img"))
            {
                await _next(context);
            }

            else
            {
                context.Request.EnableBuffering();

                var buffer = new byte[2048];
                var bytesRead = await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                if (bytesRead > 0)
                {
                    var requestBody = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Gelen JSON içeriğini JObject'e dönüştür
                    var jsonObject = JObject.Parse(requestBody);

                    // Key sayısını al
                    var keyCount = jsonObject.Properties().Count();

                    if (keyCount > 20)
                    {
                        throw new Exception("Çok model propu geldi.");
                    }
                }
                await _next(context);
            }           
        }
    }
    public static class TrimPropertiesMiddlewareExtensions
    {
        public static IApplicationBuilder TrimPropertiesMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TrimPropertiesMiddleware>();
        }
    }
}
