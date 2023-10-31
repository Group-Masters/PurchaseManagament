using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;

namespace PurchaseManagament.API.Filters
{
    public class ExceptionHandlerFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new Result<dynamic> { Success = false };
            if (context.Exception is NotFoundException notFoundException)
            {
                result.Errors = new List<string> { context.Exception.Message };

            }
            else if (context.Exception is NotMatchException notMatchException)
            {
                result.Errors = new List<string> { context.Exception.Message };

            }
            else if (context.Exception is AlreadyExistsException alreadyExistsException)
            {
                result.Errors = new List<string> { alreadyExistsException.Message };
            }
            else if (context.Exception is ValidateException validateException)
            {
                result.Errors = validateException.ErrorMessage;
            }
            else
            {
                result.Errors = new List<string>();
                {
                    result.Errors = new List<string> { context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message };

                }
            }

            context.Result = new JsonResult(result);
            context.HttpContext.Response.StatusCode = 400;
            context.ExceptionHandled = true;
        }
    }
}
