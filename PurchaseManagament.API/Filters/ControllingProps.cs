using Microsoft.AspNetCore.Mvc.Filters;

namespace PurchaseManagament.API.Filters
{
    public class ControllingProps : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            }
            else
            {
                throw new Exception("Nesne oluşturulurken gerekli olan bir özellik yok sayıldı veya verilmedi.");
            }
        }
    }
}
