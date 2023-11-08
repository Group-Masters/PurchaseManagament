using ArxOne.MrAdvice.Advice;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class ExceptionHandlerAspect : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed(); // this calls the original method
            }
            catch (Exception ex)
            {
                var result = new Result<dynamic> { Success = false };
                if (ex is NotFoundException)
                {
                    result.Errors = new List<string> { ex.Message };
                }
                else if (ex is NotMatchException)
                {
                    result.Errors = new List<string> { ex.Message };
                }
                else if (ex is AlreadyExistsException)
                {
                    result.Errors = new List<string> { ex.Message };
                }
                else if (ex is ValidateException validateException)
                {
                    result.Errors = validateException.ErrorMessage;
                }
                else
                {
                    result.Errors = new List<string> { ex.InnerException != null ? ex.InnerException.Message : ex.Message };
                }
            }
        }
    }
}
